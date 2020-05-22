#  Nhóm 1: 
## Thành viên:
* 1760171 - Nguyễn Minh Tâm
* 1760189 - Võ Sĩ Thiên
* 1760273 - Dương Mạnh Cường
  
#<center> DEADLINE nhóm tuần 5</center>

## 1. Cấu hình:
Trước khi chạy phần mềm này cần cài đặt một số package cần thiết:
* Python 3.6 (hoặc cao hơn) và một số package cần cài đặt:
  * nltk `pip install nltk`.
  * [requests_html](https://pypi.org/project/requests-html/) `pip install requests-html` (lưu ý, nếu bạn chạy python trên environment anaconda, thì trong các package mà anaconda hỗ trợ sẽ không có package này, bạn cần config lại environtment trong **System properties**, tại phần ***Path***, bạn đưa đường dẫn đến Python thuần lên đầu tiên).
  * [bs4](https://pypi.org/project/bs4/) `pip install bs4`.
  * sklearn (bạn nên follow theo các bước tại [trang này](https://calebshortt.com/2016/01/15/installing-scikit-learn-python-data-mining-library/?fbclid=IwAR0kICcfhFcZiaRxTxSXl62ub3y10XwUMg_QEqDC3goo99uDFhnvWqU7rQo) để cài đặt).
  * [langdetect](https://pypi.org/project/langdetect/) `pip install langdetect`
  * vncorenlp `pip install vncorenlp`
* Java 1.8 (download và cài đặt [tại đây](https://www.oracle.com/java/technologies/javase/javase-jdk8-downloads.html)) (có thể dùng phiên bản cao hơn).
* Bạn cần truy cập vào [trang này](https://github.com/vncorenlp/VnCoreNLP) và download zip (1) package trên đây. Giải nén ra và giữ lại các file (2), (3) mà mình đã tô đỏ, xóa các file còn lại đi.
  ![](https://f24-zpg.zdn.vn/6495283539332635159/b112df4cfcd1068f5fc0.jpg)
* Cuối cùng bạn được cây thư mục như vầy:
  