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
            if self.userInput['page'] != '':
                for i in range(1, self.userInput['nop'] + 1):
                    url = '{0}{1}{2}'.format(cate['href'], self.userInput['page'], i)

                    yield scrapy.Request(url, self.parse, meta={'direc':cate['direc']})

    def parse(self, response):
        dt.writeJson('misc/test.json', 'a', response.url)

        for thumb in self.userInput['thumb']:
            items = response.css('{0}::attr(href)'.format(thumb)).getall()

            for item in items:
                item = response.urljoin(item)
                
                yield scrapy.Request(item, self.parseDetails, meta={'direc':response.meta['direc']})

    def parseDetails(self, response):

        for det in self.userInput['detail']:
            data = response.css('{0}::text'.format(det)).getall()

            dt.writeJson('results/{1}/{0}/{0}.txt'.format(response.meta['direc'], self.userInput['domain']), 'a', data)
