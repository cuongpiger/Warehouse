import utilities.user as us, utilities.data as dt, utilities.misc as msc
import os

from modules.nlps import NLPs

# us.cleanResultsFolder()
# us.readUserInput()
# os.system('scrapy runspider scrapies/navi_spider.py')
paths = us.chooseCategory()
# os.system('scrapy runspider scrapies/thumb_spider.py')
nlps = NLPs(paths)
nlps()
