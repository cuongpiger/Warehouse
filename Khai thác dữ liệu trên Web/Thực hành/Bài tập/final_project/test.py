import os

listPath = []
for root, dirs, files in os.walk('results/vietnamnews.vn/politics-laws'):
    for file in files:
        print(file)

