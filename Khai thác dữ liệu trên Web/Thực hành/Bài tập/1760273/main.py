import json
import os
import modules.misc as msc
from scrapy.crawler import CrawlerProcess
from week_7.spiders.spider import NaviSpider, ThumbSpider

process = CrawlerProcess()

# get user's input from terminal and stripping text
""" url = input('Nhập đường dẫn trang web mà bạn cần khai thác: ').strip()
cssNavi = input('Nhập css selector của navigation bar: ').strip()
cssThumb = input("Nhập css selector của read more, thumbnail (nếu có nhiều css selector thì nhập chúng cách nhau bằng dấu `,`): ").strip().split(',')
cssDetail = input("Nhập css selector cho chi tiết của từng read more, detail (nếu có) (nếu có nhiều css selector thì nhập chúng cách nhau bằng dấu `,`): ").strip().split(',')
cssPagi = input('Nhập css selector của các pagination next (nếu có): ').strip()

data = {'url': url if url[-1] != '/' else url[:-1], 'cssNavi': cssNavi, 'cssThumb': cssThumb, 'cssDetail': cssDetail, 'cssPagi': cssPagi}

# write user's input to json file
with open('input/user_input.json', 'w') as infile:
    json.dump(data, infile) """

""" process.crawl(NaviSpider)
# process1.start() # the script will block here until the crawling is finished """

choices = msc.chooseTabContens()
msc.writeTabContentChoice(choices)

process.crawl(ThumbSpider)
process.start() # the script will block here until the crawling is finished