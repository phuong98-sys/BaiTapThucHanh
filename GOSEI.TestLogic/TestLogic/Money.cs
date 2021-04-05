using System;
using System.Collections.Generic;
using System.Text;

namespace GOSEI.TestLogic
{
    // Bài toán đổi tiền
    class Money
    {
        public long M; // số tiền cần rút ra
        public int[] valueOfMoney; // mảng chứa các mệnh giá tiền
        public string result; // kết quả tả về
        public Money()
        {
            M = 1000;
            result = "";
            valueOfMoney = new int[9] { 500, 200, 100, 50, 20, 10, 5, 2, 1 }; // khởi tạo mảng giá trị các mệnh giá với đơn vị K
        }
        // hàm lấy ra hệ số* mệnh giá ứng với số tiền truyền vào
        public string Solution()
        {
             M = long.Parse(Console.ReadLine()); // Người dùng nhập đầu vào
            int number = 0;  // hệ số của mệnh giá được chọn


            if ((M % 1000 != 0) || M < 1000 || M > 9223372036854775000) // Kiểm tra tính hợp lệ của số tiền truyền vào: có là bội của 1000 hay không và có giá trị trong khoảng yêu cầu hay không
            {
                return "M khong hop le. Hay nhap M la boi so cua 1000.";
            }

            else
            {
                M = M / 1000;    // Lấy phần nguyên để dễ dàng thực hiện hơn ( bỏ bớt 3 số 000 ở cuối)
                for (int i = 0; i < 9; i++)
                {

                    number = (int)(M / valueOfMoney[i]); // Lấy phần nguyên là hệ số của mệnh giá được xét
                    M = M % valueOfMoney[i]; // lấy phầ dư là phần tiền thừa sau khi đã xét ở mệnh giá trên
                    if (number == 0) // nếu hệ số bằng không thì ta không thêm vào chuỗi kết quả
                    {
                        continue;
                    }
                    else
                    { // Thêm vào chuỗi kết quả của hệ số * mệnh giá tương ứng
                        result = result + number + "x" + valueOfMoney[i] + "K" + " + ";
                    }


                }
                int lenght = result.Length;    
                 result = result.Substring(0, lenght-3);
                return result;
            }

        }
    }
}
