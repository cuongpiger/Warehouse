from langdetect import detect
from string import punctuation # list of special characters
from nltk.corpus import stopwords # english stopwords

sys.path.insert(1, 'utilities')
import data as dt, misc as msc

vnStopwords = dt.readTxt(r'data_config\vietnamese_stopwords_dash.txt').split('\n')
stopwords = [set(stopwords.words('english') + list(punctuation)), set(vnStopwords + list(punctuation))]
class NLP:
    def __init__(self, path):
        self.text = dt.readTxt(path)
        self.path = path[:path.rfind('/')]
        self.lang = 1 if detect(self.text) == 'vi' else 0

    def __call__(self):
        if self.text == '':
            print('Unfortunately, there was an error crawling!')
        else:
            pass

    

        