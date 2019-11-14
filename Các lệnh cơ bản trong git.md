# Các lệnh cơ bản trong Git
##### Chú ý khi nhập không nhập cặp dấu '' trong các cú pháp
|**Chức năng**|**Ý nghĩa**|**Cú pháp**|
|:---:|:---:|:---:|
|Kiểm tra thông tin|Dùng để hiển thị tất cả thông tin của git trên máy|git config --list|
|Thiết lập username|Có thể sử dụng username giả, ko cần phải là chỉnh chủ|git confi --global user.username 'username'|
|Kiểm tra username|Kiểm tra username đã được thiết lập thành công hay chưa|git config user.username|
|Thiết lập email|Thiết lập email cho git để khi commit lên không cần phải nhập lại email nữa|git config --global user.email 'email'|
|Kiểm tra email|Kiểm tra email đã được thiết lập thành công hay chưa|git config user.email|
|Thiết lập password|Thiết lập password cho git để khi commit lên không cần phải nhập lại password nữa|git config --global user.password 'password'|
|Xóa bỏ username||git config --global --unset user.username|
|Xóa bỏ password||git config --global --unset user.password|
|Xóa bỏ email||git config --global --unset user.email|
|Clone repo|**B1**. Vào repo, copy link repo cần clone<br>**B2**. Vào thư mục muốn clone repo này về<br>**B3**. Nhấp chuột phải ở trong thư mục đó sau đó mở git bash here|git clone 'link'|
|Clone repo và thay đổi tên mặc định của repo trên server|Tương tự thao tác của Clone|git clone 'link' 'new name'|
||Khi đã tồn tại một repo trên local và muốn theo dõi nó (lịch sử,...) thì cần phải tạo một init cho nó<br>**B1**. Vào thư mục cha chứa thư mục repo cần theo dõi<br>**B2**. Chuột phải chọn git bash here|git init|
|Lệnh status|Dùng để kiểm tra trạng thái các file có trong repo<br>**B1**. Vào thư mục repo cần kiểm tra<br>**B2**. Chuột phải chọn git bash here|git status|
|Đưa file về trạng thái staged|Vào thư mực repo<br>**git add -A**: stages all changes.<br>**git add .**: stages new files and modifications, without deletions.<br>**git add -u**: stages modifications and deletions, without new files.|1. git add .<br>2. git add -u<br>3. git add -A|








