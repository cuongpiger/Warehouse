""" import os

listPath = []
for root, dirs, files in os.walk('results/vietnamnews.vn/politics-laws'):
    for file in files:
        print(file)
 """


from utilities import data
from nltk.tokenize import sent_tokenize


text = data.readTxt(r'results\vietnamnews.vn\politics-laws\politics-laws.txt')

dt = sent_tokenize(text)
dt = '\n'.join(dt)

data.writeTxt('misc/text.txt', 'w', dt, False)

