Câu 1: Value Types và Reference Types
Value Types (kiểu giá trị): biến lưu trực tiếp giá trị của dữ liệu. Khi gán biến này cho biến khác, giá trị được sao chép nên hai biến độc lập nhau.

Reference Types (kiểu tham chiếu): biến lưu tham chiếu đến đối tượng trong vùng nhớ Heap. Khi gán cho biến khác, tham chiếu được sao chép nên hai biến có thể cùng trỏ đến một đối tượng.

Trong cách hiểu cơ bản, Value Type thường gắn với Stack, còn Reference Type gắn với Heap. Tuy nhiên, trên thực tế vị trí lưu trữ còn phụ thuộc vào ngữ cảnh sử dụng.

Câu 2: Init-only Properties và set
set thông thường: cho phép thuộc tính được thiết lập và thay đổi nhiều lần trong suốt vòng đời của đối tượng.

init: chỉ cho phép thiết lập giá trị trong quá trình khởi tạo đối tượng. Sau khi khởi tạo xong thì không thể thay đổi giá trị đó.

Trường hợp sử dụng: phù hợp với những dữ liệu cần được thiết lập một lần và muốn hạn chế việc thay đổi sau khi đối tượng đã được tạo, chẳng hạn như mã định danh, thông tin cấu hình hoặc các thuộc tính mang tính cố định.

Câu 3: virtual và override
virtual: được khai báo ở lớp cha, cho phép phương thức đó được lớp con thay đổi cách triển khai.

override: được khai báo ở lớp con để cung cấp cách triển khai mới cho phương thức virtual của lớp cha.

Hai từ khóa này kết hợp để thực hiện đa hình (Polymorphism). Khi chương trình gọi phương thức thông qua kiểu của lớp cha, phiên bản phương thức phù hợp với đối tượng thực tế có thể được thực thi.

Câu 4: Tại sao static không truy xuất thông qua Object Instance?
Thành phần static thuộc về lớp (Class), không thuộc về từng đối tượng (Object Instance).

Một lớp chỉ có một thành phần static dùng chung cho tất cả các đối tượng của lớp đó.

Trong khi đó, mỗi Object Instance có các thành phần riêng của nó.

Vì vậy, thành phần static được truy xuất thông qua tên lớp, thay vì thông qua một đối tượng được tạo bằng new.

Điều này giúp phân biệt rõ giữa dữ liệu dùng chung cho toàn bộ lớp và dữ liệu riêng của từng đối tượng.
