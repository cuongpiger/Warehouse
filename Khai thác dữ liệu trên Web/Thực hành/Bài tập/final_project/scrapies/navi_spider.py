import scrapy
import sys

sys.path.insert(1, 'utilities')
import data as dt, misc as msc

class NaviSpider(scrapy.Spider):
    name = 'navi'

    def __init__(self):
        self.userInput = dt.readJson('data_config/user_input.json')
        self.start_urls = [self.userInput['url']]

    def parse(self, response):
        texts = response.css('{0}::text'.format(self.userInput['navi'])).getall() # get all text of a tags
        hrefs = response.css('{0}::attr(href)'.format(self.userInput['navi'])).getall() # get all href attributes of a tags

        contents = list(map(lambda x, y: {'text': x.strip(), 'href': (y if 'http' in y else (self.userInput['url'] + '/' + y)).replace('//', '/').replace(':/', '://'), 'direc': msc.getCategory(y)}, texts, hrefs)) # convent into pair of {text, href} and store in a list
        
        # write to json file
        dt.writeJson('data_config/navi_contents.json', 'w', contents)