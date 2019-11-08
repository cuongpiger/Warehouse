**Họ tên:** _Dương Mạnh Cường_ **– MSSV:** _1760273_

# jQuery AJAX Methods
> AJAX là một kỹ thuật dùng để trao đổi dữ liệu với máy chủ, và cập nhật các thành phần của một trang web mà theo đó không cần phải load lại toàn bộ trang web.

## Các jQuery AJAX method:
### 1) $.ajax() 
Thực hiện một async (bất đồng bộ) AJAX request.
  * #### Cú pháp
    $.ajax({name:value, name:value, ... })
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| async | Là một giá trị dạng boolean. Cho biết request sẽ thực hiện theo kiểu đồng bộ hay bất đồng bộ. Mặc định là true |
| beforeSend(xhr) | Một function sẽ được chạy trước khi request được gửi |
| cache | Một giá trị boolean chỉ định trình duyệt có cần lưu trữ cache cho các trang được request hay không. Mặc định là true |
| complete(xhr,status) | Một function sẽ được thực thi khi request kết thúc (sau khi các hàm gọi lại **success** và **error** được thực thi) |
| contentType | Kiểu nội dung của dữ liệu được gửi lên server. Mặc định là _**application/x-www-form-urlencoded**_ |
| context | Một object được dùng làm ngữ cảnh (this) của tất cả các hàm gọi lại liên quan đến Ajax. |
| data | Dữ liệu được gửi lên server khi thực thi một request Ajax. |
| dataFilter(data,type) | Một hàm được dùng để xử lý các dữ liệu response thuần của một XMLHttpRequest. |
| dataType | Kiểu của dữ liệu mong muốn được trả về từ server. |
| error(xhr,status,error) | Một hàm sẽ được gọi khi request fails. |
| global | Dùng để thiết lập xem có gọi các hàm xử lý sự kiện Ajax toàn cục cho request này hay không. |
| ifModified | Thiết lập giá trị này là true nếu bạn muốn buộc JQuery nhận diện môi trường hiện tại là _**"local"**_. |
| jsonp | Một chuỗi dùng để override tên hàm gọi lại trong một request JSONP. |
| jsonpCallback | Chỉ định tên hàm gọi lại cho một request JSONP. |
| password | Mật khẩu được sử dụng với XMLHttpRequest cho response của một request yêu cầu xác thực truy nhập HTTP. |
| processData | Set giá trị này là false nếu bạn không muốn dữ liệu được truyền vào thiết lập data sẽ được xử lý và biến thành một query kiểu chuỗi. |
| scriptCharset | Thiết lập thuộc tính charset của một thẻ script dùng cho một request nhưng chỉ áp dụng khi transport script (ví dụ: request chéo giữa các domain với jsonp) được sử dụng. |
| success(result,status,xhr) | Một hàm được gọi khi request thành công. |
| timeout | Số được thiết lập chỉ định thời gian hết hạn cho một request. |
| traditional | Thiết lập giá trị true nếu bạn mong muốn param được serialize theo kiểu truyền thống. |
| type | Kiểu request muốn thực hiện, có thể là POST hay GET |
| url | Chuỗi chứa URL mà request được gửi đến. |
| username | Tên người dùng được sử dụng với XMLHttpRequest cho response của một request yêu cầu xác thực truy nhập HTTP. |
| xhr | Một hàm gọi lại dùng để tạo một object XMLHttpRequest. |

### 2) $.ajaxPrefilter() 
Thực thi một custom Ajax options hoặc sửa đổi các option đang tồn tại trước khi mỗi yêu cầu được gửi và trước khi chúng được xử lí bởi $.ajax().

### 3) $.ajaxSetup()
Thiết lập các giá trị mặc định cho những AJAX request trong tương lai.
  * #### Cú pháp
    $.ajaxSetup({name:value, name:value, ... })
  * #### Các tham số
    Tương tự như _**$.ajax()**_.

### 4) $.ajaxTransport()
Tạo ra một đối tượng để xử lí việc truyền tải dữ liệu thực tế của AJAX

### 5) $.get()
Tải dữ liệu từ một server bằng cách sử dụng một AJAX HTTP GET request.
  * #### Cú pháp
    $.get(URL,data,function(data,status,xhr),dataType)
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| URL | Chỉ định URL mà bạn muốn yêu cầu (cần phải có) |
| data | Không bắt buộc. Chỉ định dữ liệu để gửi đến server cùng với request |
| function(data,status,xhr)	| Không bắt buộc. Chỉ định một chức năng để chạy nếu request thành công. Tham số bổ sung: data - chứa các dữ liệu thu được từ các request, status - chứa các trạng thái của request ("success", "notmodified", "error", "timeout", or "parsererror"), xhr - chứa đổi tượng XMLHttpRequest |
| dataType | Không bắt buộc, chỉ định kiểu dữ liệu dự kiến từ sự trả lời của serve. Mặc định jQuery sẽ thực hiện một phỏng đoán tự động, bao gồm: "xml" - XML document, "html" - HTML dưới dạng text giản thể, "text" - chuổi, "script" - chạy response bằng JavaScript, sau đó trả về text, "json" - chạy response như JSON, và trả về đối tượng JavaScript, "jsonp" - Tải một JSON block bằng JSONP. Thêm "?callback=?" vào URL để xác định gọi lại |

### 6) $.getJSON()
Tải JSON-mã hóa dữ liệu từ một server sử dụng một yêu cầu HTTP GET
  * #### Cú pháp
    $(selector).getJSON(url,data,success(data,status,xhr))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| url | Chỉ định url để gửi yêu cầu đến (cần phải có)|
| data | Không bắt buộc. dữ liệu Xác định được gửi đến máy chủ |
| success(data,status,xhr) | Không bắt buộc. Chỉ định function để chạy nếu request thành côn, bao gồm: data - chứa dữ liệu trả về từ server, status - chứa các trạng thái từ request như ("success", "notmodified", "error", "timeout", or "parsererror"), xhr - chứa đối tượng XMLHttpRequest |

### 7) $.parseJSON()
Không sử dụng trong phiên bản 3.0, sử dụng JSON.parse () để thay thế. Lấy một chuỗi JSON và trả về kết quả là giá trị JavaScript

### 8) $.getScript()
Tải (và thực thi) một Javascript từ một server bằng HTTP GET AJAX request
  * #### Cú pháp
    $(selector).getScript(url,success(response,status))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| URL | Chỉ định URL mà bạn muốn yêu cầu (cần phải có) |
| success(response,status) | Không bắt buộc. Chỉ định function để chạy nếu request thành côn, bao gồm: response - chứa dữ liệu kết quả từ request, status - chứa các trạng thái từ request như ("success", "notmodified", "error", "timeout", or "parsererror") |

### 9) $.getScript()
Tạo ra một đại diện tuần tự của một mảng hoặc một đối tượng.
Các giá trị tuần tự có thể được sử dụng trong chuỗi truy vấn URL khi thực hiện một AJAX request.
  * #### Cú pháp
    $.param(object,trad)
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| object | Cần thiết. Chỉ định một mảng hoặc đối tượng để sắp xếp |
| trad | Không bắt buộc. Một giá trị Boolean xác định có hay không sử dụng phong cách truyền thống của param serialization |

### 10) $.post()
Tải dữ liệu từ máy chủ sử dụng một HTTP POST request.
  * #### Cú pháp
    $(selector).post(URL,data,function(data,status,xhr),dataType)
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| URL | Chỉ định URL mà bạn muốn yêu cầu (cần phải cóp |
| data | Không bắt buộc. Chỉ định dữ liệu để gửi đến máy chủ cùng với request |
| function(data,status,xhr) | Không bắt buộc. Chỉ định một chức năng để chạy nếu request thành công. Tham số bổ sung: data - chứa các dữ liệu thu được từ các request, status - chứa các trạng thái của request ("success", "notmodified", "error", "timeout", or "parsererror"), xhr - chứa đổi tượng XMLHttpRequest |
| dataType | Không bắt buộc, chỉ định kiểu dữ liệu dự kiến từ sự trả lời của serve. Mặc định jQuery sẽ thực hiện một phỏng đoán tự động, bao gồm: "xml" - XML document, "html" - HTML dưới dạng text giản thể, "text" - chuổi, "script" - chạy response bằng JavaScript, sau đó trả về text, "json" - chạy response như JSON, và trả về đối tượng JavaScript, "jsonp" - Tải một JSON block bằng JSONP. Thêm "?callback=?" vào URL để xác định gọi lại |

### 11) ajaxComplete()
Chỉ định một chức năng để chạy khi hoàn thành AJAX request
  * #### Cú pháp
    $(document).ajaxComplete(function(event,xhr,options))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| function(event,xhr,options) | Cần thiết. Quy định cụ thể chức năng để chạy khi hoàn thành request, bao gồm: event - chứa đối tượng event, xhr - chứa đối tượng XMLHttpRequest, options - chứa các tùy chọn sử dụng trong AJAX request |

### 12) ajaxError()
Chỉ định một chức năng để chạy khi hoàn thành AJAX request với có lỗi xảY ra
  * #### Cú pháp
    $(document).ajaxError(function(event,xhr,options,exc))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| function(event,xhr,options,exc)	 | Cần thiết. Quy định cụ thể chức năng để chạy khi hoàn thành request, bao gồm: event - chứa đối tượng event, xhr - chứa đối tượng XMLHttpRequest, options - chứa các tùy chọn sử dụng trong AJAX request, exc - chứa các ngoại lệ JavaScript, nếu tồn tại một cái xảy ra|

### 13) ajaxSend()
Chỉ định một chức năng để chạy khi hoàn thành AJAX request
  * #### Cú pháp
    $(document).ajaxSend(function(event,xhr,options))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| function(event,xhr,options) | Cần thiết. Quy định cụ thể chức năng để chạy khi hoàn thành request, bao gồm: event - chứa đối tượng event, xhr - chứa đối tượng XMLHttpRequest, options - chứa các tùy chọn sử dụng trong AJAX request |

### 14) ajaxStart()
Chỉ định một chức năng để chạy khi AJAX request đầu tiên bắt đầu
  * #### Cú pháp
    $(document).ajaxStart(function())
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| function() | Cần thiết. Chỉ định các chức năng để chạy khi khởi động AJAX request |

### 15) ajaxStop()
Chỉ định một chức năng để chạy khi tất cả các AJAX request đã hoàn thành
  * #### Cú pháp
    $(document).ajaxStop(function())
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| function() | Cần thiết. Chỉ định hàm để chạy khi tất cả các AJAX request đã hoàn thành |

### 16) ajaxSuccess()
Chỉ định một chức năng để chạy khi một AJAX request hoàn tất thành công
  * #### Cú pháp
    $(document).ajaxSuccess(function(event,xhr,options))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| function(event,xhr,options) | Cần thiết. Quy định cụ thể chức năng để chạy khi hoàn thành request, bao gồm: event - chứa đối tượng event, xhr - chứa đối tượng XMLHttpRequest, options - chứa các tùy chọn sử dụng trong AJAX request  |

### 17) load()
Tải dữ liệu từ một máy chủ và puts dữ liệu trả về vào thành phần được chọn
  * #### Cú pháp
    $(selector).load(url,data,function(response,status,xhr))
  * #### Các tham số
| Tên | Giá trị/ mô tả |
| :---: | :---: |
| url | Cần thiết. Chỉ định URL mà bạn muốn tải |
| data | Không bắt buộc. Chỉ định dữ liệu để gửi đến máy chủ cùng với yêu cầu |
| function(response,status,xhr) | Không bắt buộc. Chỉ định một hàm callback để chạy khi các phương pháp load () được hoàn tất, bao gồm: response - chứa dữ liệu kết quả từ request, status - chứa các trạng thái của request ("success", "notmodified", "error", "timeout", or "parsererror"), xhr - chứa đối tượng XMLHttpRequest |

### 18) serialize()
Mã hóa một tập hợp các yếu tố hình thức như là a string for submission
  * #### Cú pháp
    $(selector).serialize()

### 19) serializeArray()
Mã hóa một tập hợp các yếu tố hình thức như một mảng các name và các value
  * #### Cú pháp
    $(selector).serializeArray()

###### _Tài liệu tham thảo_
[https://freelancervietnam.vn/jquery-ajax-la-gi-va-cach-su-dung-ajax-toi-uu/](https://freelancervietnam.vn/jquery-ajax-la-gi-va-cach-su-dung-ajax-toi-uu/)

[https://www.w3schools.com/jquery/jquery_ref_ajax.asp](https://www.w3schools.com/jquery/jquery_ref_ajax.asp)




    
    
