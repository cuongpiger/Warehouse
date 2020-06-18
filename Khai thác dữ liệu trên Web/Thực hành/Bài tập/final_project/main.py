import utilities.user as us
import os

# us.readUserInput()
os.system('scrapy runspider scrapies/navi_spider.py')
us.chooseCategory()
os.system('scrapy runspider scrapies/thumb_spider.py')
