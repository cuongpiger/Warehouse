import utilities.data as dt
import os

# used to read data which user provide from terminal
def readUserInput():
    def enterCccSelectors():
        data = list()

        for i in range(1, 69):
            cssSlt = input(f'The CSS selector {i}: ').strip()
        
            if cssSlt == 'stop':
                break
        
            data.append(cssSlt)

        return data


    userInput = dict()

    userInput['url'] = input("Enter the website's URL where you need to get data: ").strip()
    userInput['url'] = userInput['url'] if userInput['url'][-1] != '/' else userInput['url'][:-1]

    userInput['navi'] = input("Enter the CSS selector of your website's navigation bar: ").strip()

    scroll = input("Does your website need using pagination to get data? [y/n]: ")

    if scroll.lower() == 'y':
        userInput['page'] = input("Enter the website's URL form that it uses pagination to get data\n(Example: http://website.com/pages?page={}): ").strip()
    else:
        userInput['page'] = ''

    print("Enter CSS selectors of thumbnails which you need to get data (enter 'stop' to ending entering process):")
    userInput['thumb'] = enterCccSelectors()

    print("Enter CSS selectors of details inside thumbnail which you need to get data (enter 'stop' to ending entering process):")
    userInput['detail'] = enterCccSelectors()

    dt.writeJson('data_config/user_input.json', 'w', userInput)


def chooseCategory():
    cates = dt.readJson('data_config/navi_contents.json')

    print("The categories obtained on the navigation bar are:")

    for i, item in enumerate(cates):
        print(f"ID: {i + 1} - Category name: {item['text']}")

    choices = list(map(int, input("Enter what category names which you want to crawl (separated by ','): ").strip().replace(' ', '').split(',')))
    data = list()

    for choice in choices:
        data.append(cates[choice - 1])
        os.mkdir(f"results/{cates[choice - 1]['direc']}")

    dt.writeJson('data_config/user_cate_choices.json', 'w', data)
