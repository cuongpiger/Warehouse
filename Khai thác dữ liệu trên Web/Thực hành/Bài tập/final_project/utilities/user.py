import utilities.data as dt, utilities.misc as msc
import os

def cleanResultsFolder():
    choice = input("Would you like to clean the results folder? [y/n]: ").strip().lower()

    if choice == 'y':
        dt.cleanFolder('results')

        print("Clean up successfully!")

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
        userInput['nop'] = int(input("Enter the number of pages you need to crawl data for each category: "))
    else:
        userInput['page'] = ''
        userInput['nop'] = -1

    print("Enter CSS selectors of thumbnails which you need to get data (enter 'stop' to ending entering process):")
    userInput['thumb'] = enterCccSelectors()

    print("Enter CSS selectors of details inside thumbnail which you need to get data (enter 'stop' to ending entering process):")
    userInput['detail'] = enterCccSelectors()

    userInput['domain'] = msc.getDomainName(userInput['url'])
    os.mkdir(f"results/{userInput['domain']}")

    dt.writeJson('data_config/user_input.json', 'w', userInput)


def chooseCategory():
    cates = dt.readJson('data_config/navi_contents.json')
    domain = msc.getDomainName(cates[0]['href'])

    print("The categories obtained on the navigation bar are:")

    for i, item in enumerate(cates):
        print(f"ID: {i + 1} - Category name: {item['text']}")

    choices = list(map(int, input("Enter what category names which you want to crawl (separated by ','): ").strip().replace(' ', '').split(',')))
    data = list()

    for choice in choices:
        data.append(cates[choice - 1])
        os.mkdir(f"results/{domain}/{cates[choice - 1]['direc']}")

    dt.writeJson('data_config/user_cate_choices.json', 'w', data)
