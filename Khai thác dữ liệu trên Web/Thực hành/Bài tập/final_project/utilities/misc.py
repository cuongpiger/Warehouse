def getCategory(path):
    return path.split('/')[-1]

def getDomainName(url):
    from tld import get_tld

    return get_tld(url, as_object=True).fld

def allowScraping(url):
    import requests

    return requests.get(url).status_code

