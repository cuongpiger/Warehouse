import scrapy
import sys

sys.path.insert(1, 'utilities')
import data as dt, misc as msc

class ThumbSpider(scrapy.Spider):
    name = 'thumb'

    def __init__(self):
        self.userInput = dt.readJson('data_config/user_input.json')
        self.cates = dt.readJson('data_config/user_cate_choices.json')

    def start_requests(self):
        for cate in self.cates:
            self.current = cate

            if self.userInput['page'] != '':
                for i in range(2, 11):
                    url = '{0}{1}{2}'.format(cate['href'], self.userInput['page'], i)

                    yield scrapy.Request(url, self.parse)

    def parse(self, response):
        for thumb in self.userInput['thumb']:
            items = response.css('{0}::attr(href)'.format(thumb)).getall()

            for item in items:
                item = response.urljoin(item)
                
                yield scrapy.Request(item, self.parseDetails)

    def parseDetails(self, response):
        for det in self.userInput['detail']:
            data = response.css('{0}::text'.format(det)).getall()

            dt.writeJson('results/{0}/{0}.txt'.format(self.current['direc']), 'a', data)
