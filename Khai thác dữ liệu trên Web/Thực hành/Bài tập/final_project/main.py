import utilities.user as us, utilities.data as dt, utilities.misc as msc
import os

# us.cleanResultsFolder()
# us.readUserInput()
os.system('scrapy runspider scrapies/navi_spider.py')
us.chooseCategory()
os.system('scrapy runspider scrapies/thumb_spider.py')

