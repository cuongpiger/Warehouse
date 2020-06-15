import scrapy
import json
import os

# read user's input from terminal storing in `input/data.json`
def readInputData(fileName):
    with open(fileName, 'rt') as jsFile:
        data = json.load(jsFile)

    return data

# spider run here
# spider to get content of navigation bar
class NaviSpider(scrapy.Spider):
    userInput = readInputData('input/user_input.json') # read user's input data
    
    name = "navi" # spider's name
    start_urls = [userInput['url']]

    def parse(self, response):
        texts = response.css('{0}::text'.format(self.userInput['cssNavi'])).getall() # get all text of a tags
        hrefs = response.css('{0}::attr(href)'.format(self.userInput['cssNavi'])).getall() # get all href attributes of a tags

        contents = list(map(lambda x, y: {'text': x.strip(), 'href': (y if 'http' in y else (self.userInput['url'] + '/' + y)).replace('//', '/')}, texts, hrefs)) # convent into pair of {text, href} and store in a list
        
        # write to json file
        with open('input/navigation.json', 'w') as infile:
            json.dump(contents, infile)

class ThumbSpider(scrapy.Spider):
    # userInput = readInputData('input/user_input.json')
    name = 'thumb'
    # start_urls = ['https://vietnamnews.vn/politics-laws', 'https://vietnamnews.vn/society']

    def __init__(self, *args, **kwargs):
        super(ThumbSpider, self).__init__(*args, **kwargs) 
        self.userInput = readInputData('input/user_input.json')
        self.start_urls = [kwargs.get('start_url')] 

        # self.urls = readInputData('input/user_choices.json')
        # self.start_urls = readInputData('input/user_choices.json')

    """ def start_requests(self):
        for url in self.urls:
            yield scrapy.Request(url = url, callback = self.parse) """

    def parse(self, response):
        for cssThumb in self.userInput['cssThumb']: # browse each cssThumb which user provides
            items = response.css('{0}::attr(href)'.format(cssThumb)).getall() # access it

            for item in items:
                item = response.urljoin(item)
                yield scrapy.Request(url=item, callback=self.parse_details)
        
        """ urls = response.css('div.vnnews-big-list-news a::attr(href)').getall()
        
        for url in urls:
            url = response.urljoin(url)

            yield scrapy.Request(url=url, callback=self.parse_details) """

    
    def parse_details(self, response):
        data = response.css('div.vnnews-text-post p span::text').extract()

        with open('result/page_content.txt', 'a') as outfile:
            json.dump(data, outfile)

        yield data

