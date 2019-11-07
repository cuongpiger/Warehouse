**Họ tên:** _Dương Mạnh Cường_ **– MSSV:** _1760273_

# AJAX Introduction

## 1. AJAX là gì:
* AJAX là chữ viết tắt của Asynchronous JavaScript and XML
* AJAX không phải ngôn ngữ lập trình.
* Là một bộ các kỹ thuật thiết kế web giúp cho các ứng dụng web hoạt động bất đồng bộ – xử lý mọi yêu cầu tới server từ phía sau.
  ### Asynchronous, JavaScript, XML trong từ AJAX là gì:
  * ##### Asynchronous:
    - Nói ngắn hơn là Async – bất đồng bộ, có nghĩa là một chương trình có thể xử lý không theo tuần tự các hàm, không có quy trình, có thể nhảy đi bỏ qua bước nào đó.
    - Ích lợi dễ thấy nhất của bất đồng bộ là chương trình có thể xử lý nhiều công việc một lúc.
  * ##### JavaScript:
    - Là một ngôn ngữ lập trình, trong số rất nhiều chức năng của nó là khả năng quản lý nội dung động của website và hỗ trợ tương tác với người dùng.
  * ##### XML:
    - Là một dạng của ngôn ngữ markup như HTML, chữ đầy đủ của nó là eXtensible Markup Language. Nếu HTML được dùng để hiển thị dữ liệu, XML được thiết kế để chứa dữ liệu.

## 2. Ví dụ thực tế của AJAX
>Hãy nhớ đến tính năng tự động hoàn thiện của Google Search. Nó giúp bạn dự đoán và hoàn thiện từ khóa trong quá trình gõ. Từ khóa thay đổi theo thời gian thực nhưng trang web của Google vẫn giữ nguyên như cũ.  Trong thập niên 90s, khi internet vẫn chưa phát triển, tính năng này cần Google phải cho tải trang lại mỗi lần có đề nghị mới hiện lên màn hình. AJAX giúp việc trao đổi dữ liệu nội bộ và presentation layer (lớp hiển thị) hoạt động đồng thời mà không ảnh hưởng đến chức năng của nhau. Ngày nay, nó đã được dùng khắp các ứng dụng web để tinh giản quá trình giao tiếp với server.

##### _**Đây là một số ví dụ khác của AJAX đang được dùng hằng ngày:**_
* **Hệ thống đánh giá và xếp hạng**
  Bạn đã từng bao giờ đưa đánh giá về sản phẩm bạn mua online chưa? Đã bao giờ thử điền form bầu chọn online chưa? Cả 2 hoạt động này chắc hẳn đều sử dụng AJAX. Khi bạn click vào nút đánh giá hay bình chọn, website sẽ nhận kết quả nhưng toàn trang web vẫn không đổi.
* **Chat rooms**
  Một số website thiết lập chat room tích hợp này trên trang chính của họ, để bạn có thể nói chuyện trực tiếp với nhân viên hỗ trợ. Nhưng bạn không phải lo việc bạn cần tải trang mỗi lần chat. AJAX không tải lại trang mỗi khi bạn gửi và nhận một tin nhắn mới. Bất đồng bộ thật lợi hại phải không!
* **Thông báo trending của Twitter**
  Twitter đã từng sử dụng AJAX cho các cập nhật mới. Mỗi lần có tweet mới trong các chủ đề nóng, Twitter sẽ cập nhật thông tin mới mà không ảnh hưởng đến trang chính.

_**Tóm lại, AJAX hoạt động đa nhiệm. Nếu bạn từng gặp trường hợp 2 tác vụ hoạt động đồng thời, một cái chạy và một cái tĩnh, có thể đó chính là sản phẩm của AJAX.**_

## 3. AJAX hoạt động như thế nào?
>AJAX không phải dùng một công nghệ duy nhất, cũng không phải ngôn ngữ lập trình. Như đã nói ở trên, AJAX là một bộ kỹ thuật phát triển web. Bộ hệ thống này bao gồm:
* **HTML/XHTML** làm ngôn ngữ chính và CSS để tạo phong cách.
* **The Document Object Model (DOM)** để hiển thị dữ liệu động và tạo tương tác.
* **XML** để trao đổi dự liệu nội bộ và **XSLT** để xử lý nó. Nhiều lập trình viên đã thay thế bằng **JSON** vì nó gần với **JavaScript** hơn.
* **XMLHttpRequest** object để giao tiếp bất đồng bộ.
* Cuối cùng, **JavaScript** làm ngôn ngữ lập trình để kết nối toàn bộ các công nghệ trên lại.

  _**Sơ đồ hoạt động**_ 
  ![Image](https://www.hostinger.vn/huong-dan/wp-content/uploads/sites/10/2019/05/so-do-hoat-dong-diagram-ajax-la-gi.jpg)
  
  | **Mô hình thông thường** | **Mô hình AJAX** |
  | :---: | :---: |
  | 1.	HTTP được gửi từ trình duyệt lên máy chủ. | 1.	Trình duyệt tạo một lệnh gọi JavaScript để kích hoạt XMLHttpRequest. |
  | 2.	Máy chủ nhận, sau đó phản truy xuất thông tin. | 2.	Ở dưới nền, trình duyệt tạo một yêu cầu HTTP gửi lên server. |
  | 3.	Server gửi dữ liệu được yêu cầu lại cho trình duyệt. | 3.	Server tiếp nhận, truy xuất và gửi lại dữ liệu cho trình duyệt. |
  | 4.	Trình duyệt nhận dữ liệu và tải lại trang để hiển thị dữ liệu lê. | 4.	Trình duyệt nhận dữ liệu từ server và ngay lập tức hiển thị lên trang. Không cần tải lại toàn bộ trang. |
  | Trong suốt quá trình này, người dùng không có lựa chọn nào khác ngoài việc chờ đợi cho đến khi toàn bộ quá trình này được thực hiện xong. Việc này không chỉ tốn thời gian, mà con áp đặt một gánh nặng không cần thiết lên trên máy chủ.||
  
   
## 3. Tổng kết
> Ưu điểm khi sử dụng AJAX là tạo ra trải nghiệm mượt mà cho người dùng. Khách truy cập không phải đợi lâu để thấy nội dung họ cần. Tuy nhiên, cũng tùy vào nhu cầu của khách truy cập nữa. Ví dụ như Google sẽ cho bạn chọn giữa AJAX và phiên bản truyền thống khi sử dụng Google Mail. Hãy đặt khách hàng lên hàng đầu mà sử dụng AJAX sao cho phù hợp.

   
###### _Tài liệu tham thảo_
[https://www.w3schools.com/js/js_ajax_intro.asp](https://www.w3schools.com/js/js_ajax_intro.asp)

[https://www.hostinger.vn/huong-dan/ajax-la-gi-va-no-hoat-dong-nhu-the-nao/#AJAX-la-gi](https://www.hostinger.vn/huong-dan/ajax-la-gi-va-no-hoat-dong-nhu-the-nao/#AJAX-la-gi)




    
    
