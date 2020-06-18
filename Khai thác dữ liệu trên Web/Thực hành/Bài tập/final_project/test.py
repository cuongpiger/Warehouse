import utilities.data as dt
from bs4 import BeautifulSoup
import re

def removeSpecialChars(text):
    string = re.sub('[^\w\s]', '', text)
    string = re.sub('\s+', ' ', string)
    string = string.strip()

    return string

text = dt.readTxt('results/vietnamnews.vn/politics-laws/politics-laws.txt')
text = removeSpecialChars(text)
print(text)