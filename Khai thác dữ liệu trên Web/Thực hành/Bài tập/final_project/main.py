import utilities.user as us, utilities.data as dt
import os

# us.cleanResultsFolder()
# us.readUserInput()
os.system('scrapy runspider scrapies/navi_spider.py')
us.chooseCategory()
os.system('scrapy runspider scrapies/thumb_spider.py')
