* **Có 3 nhánh lớn trong lĩnh vực khai thác dữ liệu trên web:**
  * Tập trung vào việc khai thác nội dung trên một trang web nào đó.
  * Khai thác liên quán đến cấu trúc web.
  * Khai thác hành vi trên web.

# KHAI THÁC NỘI DUNG WEB
* **Mục tiêu:** tìm ra các tri thức hữu ích từ nội dung của trang web.
* **Dữ liệu web:** là văn bản, hình ảnh, âm thanh, video hoặc bản tin cấu trúc khác (danh sách, bảng biểu).
## 1. Tiền xử lí văn bản
* Rút trích từ: dễ dàng đối với tiếng Anh, khó khăn với tiếng Việt, Hoa.
* Loại bỏ stop word: những từ xuất hiện thường xuyên trong nội dung của chúng ta nhưng ko quan trọng. Ví dụ: a, an, the, will, with,...
* Stemming: chuyển biến thể từ về thể gốc. Ví dụ: going => go, went => go.
* Đếm tần số xuất hiện từ và tính trọng số từ TF-IDF.
* Kỹ thuật khác: loại bỏ dấu câu, xử lí chữ hoa/thường.

### 1.1. Stop word
* Là các từ xuật hiện thường xuyên trong câu, giúp xây dựng câu nhưng ko biểu đạt dc nội dung của tài liệu. Ví dụ trong tiếng Anh có các từ: a, about, an, are, at, be, by, for,...
#### 1.1.2. Loại bỏ stop word
* Giảm được kích thước lưu trữ, có thể giảm được từ 20-30% tổng số từ trong tài liệu.
* Tăng hiệu suất và hiệu quả: stop word gây nhiễu cho quá trính tìm kiếm và khai thác văn bản.
### 1.2. Stemming
* Trong ngôn ngữ, một số từ có nhiều thể cú pháp khác nhàu phụ thuộc vào ngữ cảnh sử dụng. Ví dụ trong tiếng Anh, danh từ có số ít và số nhiều: *apple* và *apples*, động từ nguyên bản và tiếp diễn: *eat* và *eating*, động từ ở các dạng khác nhau: *eat*, *ate* và *eaten*.
#### 1.2.1. Ảnh hưởng của stemming
