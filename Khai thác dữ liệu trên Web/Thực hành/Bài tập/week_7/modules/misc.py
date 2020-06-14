import json
import os

def readInputData(fileName):
    with open(fileName) as jsFile:
        data = json.load(jsFile)

    return data

def chooseTabContens():
    data = None
    choices = None

    with open('input/navigation.json') as jsf:
        data = json.load(jsf)

    if data:
        print('Danh sách các tab content thu thập được từ navigation bar')
        for idx, item in enumerate(data):
            print(f'ID: {idx} - Tab name: {item["text"]}')

        choices = list(map(int, input('Nhập vào index của những tab name mà bạn cần khai thác (cách nhau bởi khoảng trắng): ').strip().split()))
    else:
        print('Thật đáng tiếc, trang web này đã bị chặn thu thập dữ liệu 😓')

    return choices

def writeTabContentChoice(userChoices):
    choices = []

    if userChoices:
        tabContents = readInputData('input/navigation.json')

        for i in userChoices:
            choices.append(tabContents[i]['href'])

    with open('input/user_choices.json', 'w') as outfile:
        json.dump(choices, outfile)