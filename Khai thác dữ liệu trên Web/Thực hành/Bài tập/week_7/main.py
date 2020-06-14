import json
import os
from scrapy.crawler import CrawlerProcess
from week_7.spiders.spider import NaviSpider

# get user's input from terminal and stripping text
url = input('Nhập đường dẫn trang web mà bạn cần khai thác: ').strip()
cssNavi = input('Nhập css selector của navigation bar: ').strip()
cssDetail = input('Nhập css selector của read more (nếu có): ').strip()
cssPagi = input('Nhập css selector của các pagination next (nếu có): ').strip()

data = {'url': url if url[-1] != '/' else url[:-1], 'cssNavi': cssNavi, 'cssDetail': cssDetail, 'cssPagi': cssPagi}

# write user's input to json file
with open('input/user_input.json', 'w') as infile:
    json.dump(data, infile)

process = CrawlerProcess()
process.crawl(NaviSpider)
process.start() # the script will block here until the crawling is finished