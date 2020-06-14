import scrapy
import json
import os

# read user's input from terminal storing in `input/data.json`
def readInputData(fileName):
    with open(fileName) as jsFile:
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

        contents = list(map(lambda x, y: {'text': x, 'href': y}, texts, hrefs)) # convent into pair of {text, href} and store in a list
        
        # write to json file
        with open('input/navigation.json', 'w') as infile:
            json.dump(contents, infile)


