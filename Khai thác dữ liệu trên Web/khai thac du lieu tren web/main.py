# thư viện dùng để lấy file raw html từ một url
import urllib.request as urlreq

class DataPreprocessing:
    # p.thức khởi tạo nhận vào một `url`
    def __init__(self, url, segments):
        self.url = url
        self.segments = sorted(segments)

    # p.thức đọc file raw html và lưu vào một attribute của class là `rawHtml`
    def getRawHtml(self):
        fp = fp = urlreq.urlopen(self.url)
        myBytes = fp.read()
        self.rawHtml = myBytes.decode('utf-8')
        fp.close()

    # p.thức để ghi ra file bao gồm `fileName` là đường dẫn cần ghi file vào, `attri` là attribute của class cần lấy thông tin ra để ghi
    def writeFile(self, fileName, attri):
        f = open(fileName, 'w')
        f.write(getattr(self, attri))
        f.close()

    def readSegment(self, fileName):
        fp = open(fileName, 'r')
        left, right = 0, 1
        content = ''

        for i, line in enumerate(fp):
            if left > len(self.segments) or right > len(self.segments):
                break

            if i >= self.segments[right]:
                left += 2
                right += 2

            if left < len(self.segments) and right < len(self.segments) and i >= self.segments[left] - 1 and i < self.segments[right]:
                content += line
    
        fp.close()
        self.content = content

    def __call__(self):
        self.getRawHtml()
        self.writeFile('./results/raw_html.txt', 'rawHtml')
        self.readSegment('./results/raw_html.txt')
        self.writeFile('./results/segments.txt', 'content')


segments = [144, 150]
dataPre = DataPreprocessing('https://techcrunch.com/2020/05/15/3-views-on-the-future-of-work-coffee-shops-and-neighborhoods-in-a-post-pandemic-world/', segments)
dataPre()