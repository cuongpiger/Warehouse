with open("input/user_choices.txt", "rt") as f:
    start_urls = [url.strip() for url in f.readlines()]

    print(start_urls)