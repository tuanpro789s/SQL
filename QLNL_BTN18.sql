create database QLNH_LauNuong_BTN18;
use QLNH_LauNuong_BTN18

DROP LOGIN nvPV;


-- Quyền Nhân viên phục vụ
CREATE LOGIN NhanVienPhucVu WITH PASSWORD = '64130603';
CREATE USER NhanVienPhucVu FOR LOGIN NhanVienPhucVu;
GRANT SELECT ON MonAn TO NhanVienPhucVu;
GRANT SELECT ON DanhMuc TO NhanVienPhucVu;
GRANT SELECT, UPDATE ON DatBan TO NhanVienPhucVu;
GRANT SELECT ON HoaDon TO NhanVienPhucVu;
GRANT SELECT ON ChiTietHoaDon TO NhanVienPhucVu;

-- Quyền quản trị viên
GO
CREATE LOGIN AdminQTV WITH PASSWORD = 'Tuantieutienti123';
CREATE USER AdminQTV FOR LOGIN AdminQTV
ALTER ROLE db_owner ADD MEMBER AdminQTV;
GO

-- Quyền nhân viên thu ngân
GO
CREATE LOGIN moneyNV WITH PASSWORD = '62131775';
CREATE USER moneyNV FOR LOGIN moneyNV;
GRANT SELECT, INSERT, UPDATE ON HoaDon TO moneyNV;
GRANT SELECT, INSERT, UPDATE ON ChiTietHoaDon TO moneyNV;

SELECT name, type_desc, create_date
FROM sys.database_principals
WHERE type IN ('S', 'U');


CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

INSERT INTO Users (Username, Password, Role) VALUES ('nhanvien1', 'password1', 'NhanVienPhucVu');
INSERT INTO Users (Username, Password, Role) VALUES ('admin1', 'adminpass', 'AdminQTV');
INSERT INTO Users (Username, Password, Role) VALUES ('thuquy1', 'thuquypass', 'moneyNV');


-- Tạo bảng Danh Mục
CREATE TABLE DanhMuc (
    ma_danh_muc varchar(5) PRIMARY KEY,
    ten_danh_muc NVARCHAR(100) NOT NULL
);

-- Tạo bảng Món Ăn
CREATE TABLE MonAn (
    ma_mon_an varchar(5) PRIMARY KEY,
    ten_mon_an NVARCHAR(100) NOT NULL,
    gia DECIMAL(10, 2) NOT NULL,
    ma_danh_muc varchar(5),
    FOREIGN KEY (ma_danh_muc) REFERENCES DanhMuc(ma_danh_muc)
);

-- Tạo bảng nguyên liệu
CREATE TABLE NguyenLieu (
    ma_nguyen_lieu varchar(5) PRIMARY KEY,
    ten_nguyen_lieu NVARCHAR(100) NOT NULL,
    don_vi NVARCHAR(20),
    gia_per_don_vi DECIMAL(10, 2)
);

-- Tạo bảng quan hệ Nguyên liệu cho Món Ăn
CREATE TABLE MonAn_NguyenLieu (
    ma_mon_an varchar(5),
    ma_nguyen_lieu varchar(5),
    so_luong INT,
    PRIMARY KEY (ma_mon_an, ma_nguyen_lieu),
    FOREIGN KEY (ma_mon_an) REFERENCES MonAn(ma_mon_an),
    FOREIGN KEY (ma_nguyen_lieu) REFERENCES NguyenLieu(ma_nguyen_lieu)
);

-- Tạo bảng Khách Hàng
CREATE TABLE KhachHang (
    ma_khach_hang varchar(5) PRIMARY KEY,
    ten_khach_hang NVARCHAR(100) NOT NULL,
    so_dien_thoai VARCHAR(20),
    dia_chi NVARCHAR(200)
);

-- Tạo bảng Hóa Đơn
CREATE TABLE HoaDon (
    ma_hoa_don varchar(5) PRIMARY KEY,
    ma_khach_hang varchar(5),
    ngay DATE,
    tong_tien DECIMAL(10, 2),
    FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang)
);

-- Tạo bảng Nhân viên
CREATE TABLE NhanVien (
    ma_nhan_vien varchar(5) PRIMARY KEY,
    ten_nhan_vien NVARCHAR(100) NOT NULL,
    sdt VARCHAR(20),
    dia_chi NVARCHAR(200)
);

-- Tạo bảng chi tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon (
    ma_chi_tiet_hoa_don varchar(5) PRIMARY KEY,
    ma_hoa_don varchar(5),
    ma_mon_an varchar(5),
    so_luong INT,
    ma_nhan_vien varchar(5),
    FOREIGN KEY (ma_hoa_don) REFERENCES HoaDon(ma_hoa_don),
    FOREIGN KEY (ma_mon_an) REFERENCES MonAn(ma_mon_an),
    FOREIGN KEY (ma_nhan_vien) REFERENCES NhanVien(ma_nhan_vien)
);

-- Tạo bảng Đặt Bàn
CREATE TABLE DatBan (
    ma_ban varchar(5) PRIMARY KEY,
    tinh_trang NVARCHAR(50),
    so_luong INT,
    ten_khach_hang NVARCHAR(100)  ,
    ma_khach_hang varchar(5)
	foreign key(ma_khach_hang) references Khachhang(ma_khach_hang)
);

--Tạo bảng Tồn Kho
CREATE TABLE TonKho (
    ma_san_pham varchar(5) PRIMARY KEY,
    ten_san_pham NVARCHAR(100) NOT NULL,
    gia DECIMAL(10, 2),
    so_luong INT,
    gia_mua DECIMAL(10, 2),
    FOREIGN KEY (ma_san_pham) REFERENCES NguyenLieu(ma_nguyen_lieu)
);

-- Tạo bảng nhà cung cấp
CREATE TABLE NhaCungCap (
    ma_nha_cung_cap varchar(5) PRIMARY KEY,
    ten_nha_cung_cap NVARCHAR(100) NOT NULL,
    dia_chi NVARCHAR(200),
    so_dien_thoai VARCHAR(20)
);

-- Tạo bảng Hóa đơn của nguyên liệu
CREATE TABLE HoaDonNguyenLieu (
    ma_hoa_don_nguyen_lieu varchar(5) PRIMARY KEY,
    ma_nha_cung_cap varchar(5),
    ngay DATE,
    tong_tien DECIMAL(10, 2),
    FOREIGN KEY (ma_nha_cung_cap) REFERENCES NhaCungCap(ma_nha_cung_cap)
);

-- Tạo bảng chi tiết về giá của nguyên liệu
CREATE TABLE ChiTietGiaNguyenLieu (
    ma_chi_tiet_gia_nguyen_lieu varchar(5) PRIMARY KEY,
    ma_nguyen_lieu varchar(5),
    ngay_ap_dung DATE,
    FOREIGN KEY (ma_nguyen_lieu) REFERENCES NguyenLieu(ma_nguyen_lieu)
);

-- Chèn dữ liệu bảng danh mục
INSERT INTO DanhMuc (ma_danh_muc, ten_danh_muc) VALUES
('DM01', N'Lẩu truyền thống'),
('DM02', N'Lẩu đặc biệt'),
('DM03', N'Lẩu Buffet'),
('DM04', N'Lẩu Cặp Đôi'),
('DM05', N'Thịt'),
('DM06', N'Rau'),
('DM07', N'Đồ uống cồn'),
('DM08', N'Đồ Uống ngọt');

-- Chèn dữ liệu bảng Món Ăn
INSERT INTO MonAn (ma_mon_an, ten_mon_an, gia, ma_danh_muc) VALUES
('MA01', N'Lẩu Thái', 250000, 'DM01'),
('MA02', N'Lẩu Nấm', 220000, 'DM01'),
('MA03', N'Lẩu Hải Sản', 280000, 'DM02'),
('MA04', N'Lẩu Gà é', 150000, 'DM03'),
('MA05', N'Lẩu uyên ương', 180000, 'DM04'),
('MA06', N'Bò nướng', 25000, 'DM05'),
('MA07', N'Gà nướng',20000,'DM05'),
('MA08', N'Kim Chi',15000,'DM06'),
('MA09', N'Bia',9000,'DM07'),
('MA10', N'Soda', 15000, 'DM08');

-- Chèn dữ liệu bảng nguyên liệu
INSERT INTO NguyenLieu (ma_nguyen_lieu, ten_nguyen_lieu, don_vi, gia_per_don_vi) VALUES
('NL01', N'Thịt Bò', 'Kg', 200000),
('NL02', N'Thịt Gà', 'Kg', 150000),
('NL03', N'Cá Sông', 'Kg', 180000),
('NL04', N'Hải Sản Tươi', 'Kg', 250000),
('NL05', N'Rau Cải', 'Kg', 30000),
('NL06', N'Nấm Hương', 'Kg', 80000),
('NL07', N'Cà Rốt', 'Kg', 25000),
('NL08', N'Bia Tiger','Thùng',300000),
('NL09', N'CoCa','Thùng',150000),
('NL10', N'Nước lọc','Thùng',100000);

-- Chèn dữ liệu bảng quan hệ nguyên liệu và món ăn
INSERT INTO MonAn_NguyenLieu (ma_mon_an, ma_nguyen_lieu, so_luong) VALUES
('MA02', 'NL06', 3),
('MA02', 'NL05', 6),
('MA03', 'NL03', 1),
('MA03', 'NL04', 2),
('MA04', 'NL02', 0.5),
('MA05', 'NL03', 0.5),
('MA05', 'NL04', 0.5),
('MA07', 'NL02',1),
('MA09', 'NL08',1),
('MA10', 'NL09',1);

-- Chèn dữ liệu bảng khách hàng
INSERT INTO KhachHang (ma_khach_hang, ten_khach_hang, so_dien_thoai, dia_chi) VALUES
('KH01', N'Kim Vân', '0123456789', N'87 Phan Đình Phùng, Đà Lạt'),
('KH02', N'Đại Mao', '0907654321', N'211 Lê Lợi, Di Linh'),
('KH03', N'Hàng Bách', '0887654321', N'12 Bách Tông, Vạn Môn'),
('KH04', N'Thiên Vân', '0587654321', N'3 Khương Lâm, Cao Lục'),
('KH05', N'Ngọa Môn', '0977654321', N'80 Thanh Môn, Vân Tông'),
('KH06', N'Tây Hành', '0937654321', N'1 Đại Bách, Triều Đức'),
('KH07', N'Vũ Hóa', '0987154321', N'19 Tông Dạ,Tông Thiên'),
('KH08', N'Triều Thiên', '0187654321', N'5 Địa Lao, Địa lục'),
('KH09', N'Trần Kim', '0967654321', N'6 Thiên Môn, Thiên Phong'),
('KH10', N'Thiên Tà', '0997654321', N'198 Cung Vũ, Cung Tông');

-- chèn dữ liệu bảng Hóa đơn
INSERT INTO HoaDon (ma_hoa_don, ma_khach_hang, ngay, tong_tien) VALUES
('HD01', 'KH01', '2020-08-01', 500000),
('HD02', 'KH01', '2021-12-12', 380000),
('HD03', 'KH02', '2021-12-12', 500000),
('HD04', 'KH03', '2022-04-12', 450000),
('HD05', 'KH04', '2023-04-12', 750000),
('HD06', 'KH05', '2023-06-20', 150000),
('HD07', 'KH06', '2023-09-15', 800000),
('HD08', 'KH07', '2023-12-25', 700000),
('HD09', 'KH08', '2024-02-29', 500000),
('HD10', 'KH09', '2024-04-01', 900000),
('HD11', 'KH10', '2024-04-01', 500000);

-- chèn dữ liệu bảng nhân viên
INSERT INTO NhanVien (ma_nhan_vien, ten_nhan_vien, sdt, dia_chi) VALUES
('NV01', N'Nguyễn Thiến', '0369876543', N'789 Trần Phú, Đà Lạt'),
('NV02', N'Trần Ngọc', '0987456321', N'456 Hùng Vương, Đà Lạt'),
('NV03', N'Lê Giang', '0123456789', N'123 Lê Lợi, Hồ Chí Minh'),
('NV04', N'Phạm Huyền', '0998877665', N'234 Nguyễn Huệ, Hồ Chí Minh'),
('NV05', N'Trần Thị Ngân', '0887766554', N'345 Võ Văn Tần, Nha Trang'),
('NV06', N'Lê Văn Phở', '0776655443', N'456 Lê Lai, Nha Trang'),
('NV07', N'Nguyễn Thị Tuyền', '0665544332', N'567 Lý Tự Trọng, Đà Lạt'),
('NV08', N'Hoàng Văn Hám', '0554433221', N'678 Hai Bà Trưng, Hà Nội'),
('NV09', N'Trần Thị Tĩng', '0443322110', N'789 Nguyễn Đình Chiểu, Huế'),
('NV10', N'Phan Văn Khảm', '0332211009', N'890 Điện Biên Phủ, Huế');

-- chèn dữ liệu bảng chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (ma_chi_tiet_hoa_don, ma_hoa_don, ma_mon_an, so_luong, ma_nhan_vien) VALUES
('CHD01', 'HD01', 'MA01', 1, 'NV01'),
('CHD02', 'HD01', 'MA02', 1, 'NV01'),
('CHD03', 'HD02', 'MA04', 1, 'NV02'),
('CHD04', 'HD02', 'MA05', 1, 'NV03'),
('CHD05', 'HD03', 'MA06', 1, 'NV04'),
('CHD06', 'HD05', 'MA07', 1, 'NV06'),
('CHD07', 'HD04', 'MA08', 1, 'NV07'),
('CHD08', 'HD06', 'MA09', 1, 'NV10'),
('CHD09', 'HD07', 'MA10', 1, 'NV09'),
('CHD10', 'HD08', 'MA03', 1, 'NV08');

-- chèn dữ liệu bảng đặt bàn
INSERT INTO DatBan (ma_ban, tinh_trang, so_luong, ten_khach_hang, ma_khach_hang) VALUES
('B01', N'Trống', 6, N'Kim Vân', 'KH01'),
('B02', N'Đã Đặt', 4, N'Đại Mao', 'KH02'),
('B03', N'Trống', 5, N'Hàng Bách', 'KH03'),
('B04', N'Đã Đặt', 3, N'Thiên Vân', 'KH04'),
('B05', N'Trống', 7, N'Ngọa Môn', 'KH05'),
('B06', N'Trống', 4, N'Tây Hành', 'KH06'),
('B07', N'Đã Đặt', 6, N'Vũ Hóa', 'KH07'),
('B08', N'Trống', 5, N'Triều Thiên', 'KH08'),
('B09', N'Đã Đặt', 2, N'Trần Kim', 'KH09'),
('B10', N'Trống', 4, N'Thiên Tà', 'KH10');

-- chèn dữ liệu bảng tồn kho
INSERT INTO TonKho (ma_san_pham, ten_san_pham, gia, so_luong, gia_mua) VALUES
('NL01', N'Thịt Bò', 200000, 50, 180000),
('NL02', N'Thịt Gà', 150000, 30, 130000),
('NL04', N'Hải Sản Tươi', 250000, 15, 220000),
('NL05', N'Rau Cải', 30000, 100, 25000),
('NL06', N'Nấm Hương', 80000, 50, 70000),
('NL08', N'Bia Tiger', 300000, 20, 270000),
('NL09', N'CoCa', 150000, 20, 130000),
('NL10', N'Nước lọc', 100000, 30, 90000);

-- Chèn dữ liệu bảng nhà cung cấp
INSERT INTO NhaCungCap (ma_nha_cung_cap, ten_nha_cung_cap, dia_chi, so_dien_thoai) VALUES
('NCC01', N'Nhà cung cấp thịt', N'Đường Trần Phú, TP. Đà Lạt', '0123456789'),
('NCC02', N'Nhà cung cấp rau cải', N'Đường Hoài Xuân, TP. Đà Lạt', '0987654321'),
('NCC03', N'Nhà cung cấp hải sản', N'Đường Phúc Nhõ, TP. Đà Lạt', '0369852147'),
('NCC04', N'Nhà cung cấp nước ngọt', N'Đường PQR, TP. Đà Lạt', '0258741369'),
('NCC05', N'Nhà cung cấp bia', N'Đường Dai Phong, TP. Đà Lạt', '0325478961'),
('NCC06', N'Nhà cung cấp cà rốt', N'Đường Phong Ba, TP. Đà Lạt', '0147852369'),
('NCC07', N'Nhà cung cấp nấm', N'Đường Yersin, TP. Đà Lạt', '0369852147'),
('NCC08', N'Nhà cung cấp cà phê', N'Đường Kim Huyền, TP. Đà Lạt', '0258741369'),
('NCC09', N'Nhà cung cấp rượu vang', N'Đường Huyền Ngọc, TP. Đà Lạt', '0325478961'),
('NCC10', N'Nhà cung cấp đồ uống khác', N'Đường Thiên Nữ, TP. Đà Lạt', '0147852369');

-- Chèn dữ liệu bảng hóa đơn nguyên liệu
INSERT INTO HoaDonNguyenLieu (ma_hoa_don_nguyen_lieu, ma_nha_cung_cap, ngay, tong_tien) VALUES
('HNL01', 'NCC01', '2020-04-10', 400000),
('HNL02', 'NCC02', '2020-04-11', 300000),
('HNL03', 'NCC03', '2021-04-12', 350000),
('HNL04', 'NCC04', '2021-04-10', 250000),
('HNL05', 'NCC05', '2022-04-11', 200000),
('HNL06', 'NCC06', '2022-04-12', 150000),
('HNL07', 'NCC07', '2023-04-10', 180000),
('HNL08', 'NCC08', '2023-04-11', 220000),
('HNL09', 'NCC09', '2024-04-12', 270000),
('HNL10', 'NCC10', '2024-04-10', 320000);

-- Chèn dữ liệu vào bảng chi tiết giá nguyên liệu
INSERT INTO ChiTietGiaNguyenLieu (ma_chi_tiet_gia_nguyen_lieu, ma_nguyen_lieu, ngay_ap_dung) VALUES
('GNL01', 'NL01', '2020-04-10'),
('GNL02', 'NL02', '2020-04-11'),
('GNL03', 'NL03', '2021-04-12'),
('GNL04', 'NL04', '2021-04-10'),
('GNL05', 'NL05', '2022-04-11'),
('GNL06', 'NL06', '2022-04-12'),
('GNL07', 'NL07', '2023-04-10'),
('GNL08', 'NL08', '2023-04-11'),
('GNL09', 'NL09', '2024-04-12'),
('GNL10', 'NL10', '2024-04-10');

-- 3 câu truy vấn đơn giản

-- Hiển thị toàn bộ thông tin trong bảng MonAn
SELECT * FROM MonAn;

-- Lấy tên và số điện thoại của tất cả khách hàng
SELECT ten_khach_hang, so_dien_thoai FROM KhachHang;

-- hiển thị danh sách nhân viên ở Nha Trang
SELECT * FROM NhanVien WHERE dia_chi LIKE '%Nha Trang%';

-- 7 Truy vấn với Aggregate Functions

-- Tính tổng giá trị của tất cả các hóa đơn
SELECT SUM(tong_tien) AS tong_gia_tri_hoa_don FROM HoaDon;

-- Tính trung bình giá của các món ăn
SELECT AVG(gia) AS gia_trung_binh_mon_an FROM MonAn;

-- Tính giá trị lớn nhất của nguyên liệu
SELECT MAX(gia_per_don_vi) AS gia_lon_nhat_nguyen_lieu FROM NguyenLieu;

-- Tính giá trị nhỏ nhất của đơn vị tồn kho
SELECT MIN(so_luong) AS so_luong_nho_nhat_ton_kho FROM TonKho;

-- Tính tổng số lượng món ăn được đặt bàn
SELECT SUM(so_luong) AS tong_so_luong_dat_ban FROM DatBan;

-- Tính trung bình số lượng nguyên liệu cần cho mỗi món ăn
SELECT AVG(so_luong) AS so_luong_trung_binh_nguyen_lieu FROM MonAn_NguyenLieu;

-- Tính tổng số lượng hóa đơn của mỗi khách hàng
SELECT ma_khach_hang, COUNT(*) AS so_luong_hoa_don FROM HoaDon GROUP BY ma_khach_hang;

-- 5 Truy vấn với mệnh đề having

-- Hiển thị các nhà cung cấp có tổng giá trị hóa đơn nguyên liệu lớn hơn 200,000 đồng
SELECT ma_nha_cung_cap, SUM(tong_tien) AS tong_gia_tri_hoa_don
FROM HoaDonNguyenLieu
GROUP BY ma_nha_cung_cap
HAVING SUM(tong_tien) > 200000;

-- Liệt kê các món ăn có số lượng đặt bàn ít hơn 5
SELECT ma_mon_an, COUNT(*) AS so_lan_dat_ban
FROM ChiTietHoaDon
GROUP BY ma_mon_an
HAVING COUNT(*) < 5;

-- Hiển thị các khách hàng có tổng số lượng hóa đơn lớn hơn 1
SELECT ma_khach_hang, COUNT(*) AS so_luong_hoa_don
FROM HoaDon
GROUP BY ma_khach_hang
HAVING COUNT(*) > 1;

-- Hiển thị các nhà cung cấp có tổng số lượng hóa đơn nguyên liệu ít hơn 3
SELECT ma_nha_cung_cap, COUNT(*) AS so_luong_hoa_don
FROM HoaDonNguyenLieu
GROUP BY ma_nha_cung_cap
HAVING COUNT(*) < 3;

-- Liệt kê các món ăn có giá trị trung bình lớn hơn 200,000 đồng
SELECT ma_mon_an, AVG(gia) AS gia_trung_binh
FROM MonAn
GROUP BY ma_mon_an
HAVING AVG(gia) > 200000;

-- 3 Truy vấn lớn nhất, nhỏ nhất

-- Nguyên liệu có giá thấp nhất
SELECT TOP 1 * FROM NguyenLieu ORDER BY gia_per_don_vi ASC;

-- Nguyên liệu có giá cao nhất
SELECT TOP 1 * FROM NguyenLieu ORDER BY gia_per_don_vi DESC;

-- Món ăn có giá cao nhất
SELECT TOP 1 * FROM MonAn ORDER BY gia DESC;

-- 7 Truy vấn Không/chưa có: (Not In và left/right join)

-- Liệt kê các món ăn chưa có trong thực đơn của danh mục "Lẩu truyền thống"
SELECT M.ten_mon_an
FROM MonAn M
WHERE M.ma_danh_muc = 'DM01'
AND M.ma_mon_an NOT IN (
    SELECT MA.ma_mon_an
    FROM MonAn_NguyenLieu MA
);

-- Liệt kê tên các nhà cung cấp chưa cung cấp nguyên liệu nào cho nhà hàng
SELECT NCC.ten_nha_cung_cap
FROM NhaCungCap NCC
WHERE NCC.ma_nha_cung_cap NOT IN (
    SELECT HNL.ma_nha_cung_cap
    FROM HoaDonNguyenLieu HNL
);

-- Liệt kê các khách hàng có tổng chi tiêu cao nhất
SELECT TOP 10 KH.ten_khach_hang, SUM(HD.tong_tien) AS tong_chi_tieu
FROM KhachHang KH
JOIN HoaDon HD ON KH.ma_khach_hang = HD.ma_khach_hang
GROUP BY KH.ten_khach_hang
ORDER BY tong_chi_tieu DESC;

-- Danh sách các món ăn đã có trong bảng đặt bàn
SELECT ma_mon_an, ten_mon_an
FROM MonAn
WHERE ma_mon_an IN (SELECT DISTINCT ma_mon_an FROM ChiTietHoaDon);

-- Danh sách các khách hàng đã có hóa đơn
SELECT ma_khach_hang, ten_khach_hang
FROM KhachHang
WHERE ma_khach_hang IN (SELECT DISTINCT ma_khach_hang FROM HoaDon);

-- Danh sách các nguyên liệu đã được sử dụng trong món ăn
SELECT ma_nguyen_lieu, ten_nguyen_lieu
FROM NguyenLieu
WHERE ma_nguyen_lieu IN (SELECT DISTINCT ma_nguyen_lieu FROM MonAn_NguyenLieu);

-- Liệt kê tên các nhân viên chưa có hóa đơn nào được thanh toán
SELECT NV.ten_nhan_vien
FROM NhanVien NV
WHERE NV.ma_nhan_vien NOT IN (
    SELECT CTHD.ma_nhan_vien
    FROM ChiTietHoaDon CTHD
);

-- 3 Truy vấn Hợp/Giao/Trừ

-- kết hợp tất cả các hóa đơn món ăn và hóa đơn nguyên liệu thành một danh sách duy nhất
SELECT 'Món Ăn' AS Loai, ma_hoa_don AS MaHoaDon, ngay AS Ngay, tong_tien AS TongTien
FROM HoaDon
UNION ALL
SELECT 'Nguyên Liệu' AS Loai, ma_hoa_don_nguyen_lieu AS MaHoaDon, ngay AS Ngay, tong_tien AS TongTien
FROM HoaDonNguyenLieu
ORDER BY Ngay;

-- lấy ra các hóa đơn mà cả hai loại hóa đơn (món ăn và nguyên liệu) đều có
SELECT ma_hoa_don AS MaHoaDon
FROM HoaDon
WHERE ma_hoa_don IN (SELECT ma_hoa_don_nguyen_lieu FROM HoaDonNguyenLieu);

-- lấy ra các hóa đơn món ăn không có trong danh sách hóa đơn nguyên liệu
SELECT ma_hoa_don AS MaHoaDon, ngay AS Ngay, tong_tien AS TongTien
FROM HoaDon
WHERE ma_hoa_don NOT IN (SELECT ma_hoa_don_nguyen_lieu FROM HoaDonNguyenLieu);

-- 7 Truy vấn Update, Delete
-- Cập nhật thông tin của một món ăn
UPDATE MonAn
SET ten_mon_an = N'Lẩu Thái Hải Sản'
WHERE ma_mon_an = 'MA01';

SELECT * FROM MonAn;


-- Cập nhật số lượng bàn trong đặt bàn
UPDATE DatBan
SET so_luong = 6
WHERE ma_ban = 'B01';

-- Cập nhật số lượng tồn kho của một nguyên liệu
UPDATE TonKho
SET so_luong = so_luong - 10
WHERE ma_san_pham = 'NL01';

SELECT * FROM TonKho;

--Xóa một món ăn khỏi danh sách
UPDATE MonAn_NguyenLieu
SET ma_mon_an = NULL
WHERE ma_mon_an = 'MA01';
UPDATE ChiTietHoaDon
SET ma_mon_an = NULL
WHERE ma_mon_an = 'MA01';
DELETE FROM MonAn
WHERE ma_mon_an = 'MA01';

SELECT * FROM MonAn;

--Xóa một khách hàng khỏi danh sách
UPDATE HoaDon
SET ma_khach_hang = NULL
WHERE ma_khach_hang = 'KH08';
UPDATE DatBan
SET ma_khach_hang = NULL
WHERE ma_khach_hang = 'KH08';
DELETE FROM KhachHang
WHERE ma_khach_hang = 'KH08';

SELECT * FROM KhachHang;

-- Xóa một hóa đơn
DELETE FROM HoaDon
WHERE ma_hoa_don = 'HD11';

SELECT * FROM HoaDon;

-- Xóa thông tin đặt bàn
DELETE FROM DatBan
WHERE ma_ban = 'B10';	

SELECT * FROM DatBan;

GO
-- Tạo 5 thủ tục/hàm 
-- Thêm chèn món ăn mới 
CREATE PROCEDURE Them_MonAn
(
    @MaMonAn varchar(5),
    @TenMonAn nvarchar(100),
    @Gia decimal(10, 2),
    @MaDanhMuc varchar(5)
)
AS
BEGIN
-- Thêm món ăn mới vào bảng MonAn
    INSERT INTO MonAn (ma_mon_an, ten_mon_an, gia, ma_danh_muc)
    VALUES (@MaMonAn, @TenMonAn, @Gia, @MaDanhMuc);
END
-- Gọi Hàm
EXEC Them_MonAn
    @MaMonAn = 'MA11',
    @TenMonAn = N'Lẩu cá kèo',
    @Gia = 300000,
    @MaDanhMuc = 'DM01';

SELECT * FROM MonAn;

GO
-- Tìm Hóa Đơn Theo Mã Khách Hàng
CREATE PROCEDURE TimHoaDonTheoMaKhachHang
    @ma_khach_hang VARCHAR(5)
AS
BEGIN
    SELECT * FROM HoaDon WHERE ma_khach_hang = @ma_khach_hang;
END;
--Gọi hàm
EXECUTE TimHoaDonTheoMaKhachHang 'KH01';

GO
--Tính tổng doanh thu theo tháng
CREATE PROCEDURE TongDoanhThuTheoThang
    @thang_nam VARCHAR(7)
AS
BEGIN
    SELECT SUM(tong_tien) AS tong_doanh_thu FROM HoaDon WHERE FORMAT(ngay, 'yyyy-MM') = @thang_nam;
END;
-- Gọi Hàm
EXECUTE TongDoanhThuTheoThang '2024-04';

GO
-- Cập Nhật Số Lượng Tồn Kho
CREATE PROCEDURE CapNhatSoLuongTonKho
    @ma_nguyen_lieu VARCHAR(5),
    @so_luong_nhap INT
AS
BEGIN
    UPDATE TonKho SET so_luong = so_luong + @so_luong_nhap WHERE ma_san_pham = @ma_nguyen_lieu;
END;
-- Gọi Hàm
EXECUTE CapNhatSoLuongTonKho 'NL01', 20;

SELECT * FROM TonKho;

GO
-- Hàm Xóa Bàn Đã Đặt
CREATE PROCEDURE XoaBanDaDat
    @ma_ban VARCHAR(5)
AS
BEGIN
    DELETE FROM DatBan WHERE ma_ban = @ma_ban AND tinh_trang = N'Đã Đặt';
END;
-- Gọi Hàm
EXECUTE XoaBanDaDat 'B09';

SELECT * FROM DatBan;

-- Tạo 3 câu trigger
-- Cảnh báo việc xóa khách hàng
GO
CREATE TRIGGER Trigger_TruocXoaKhachHang
ON KhachHang
INSTEAD OF DELETE
AS
BEGIN
    -- Kiểm tra xem khách hàng có hóa đơn hoặc dữ liệu liên quan không
    IF EXISTS (SELECT 1 FROM HoaDon WHERE ma_khach_hang IN (SELECT ma_khach_hang FROM deleted))
    BEGIN
        PRINT N'Không thể xóa khách hàng này vì có hóa đơn liên quan.';
    END
    ELSE
    BEGIN
        -- Xóa khách hàng nếu không có dữ liệu liên quan
        DELETE FROM KhachHang WHERE ma_khach_hang IN (SELECT ma_khach_hang FROM deleted);
    END;
END;

DELETE FROM KhachHang WHERE ma_khach_hang = 'KH01';



-- Kiểm tra cập nhật tồn kho
GO
CREATE TRIGGER Trigger_CapNhatTonKho
ON TonKho
INSTEAD OF UPDATE
AS
BEGIN
    -- Kiểm tra nếu số lượng tồn kho sẽ âm sau khi cập nhật
    IF EXISTS (SELECT * FROM inserted WHERE so_luong < 0)
    BEGIN
        PRINT N'Số lượng tồn kho không thể âm.';
    END
    ELSE
    BEGIN
        -- Tiến hành cập nhật số lượng tồn kho
        UPDATE TonKho 
        SET so_luong = i.so_luong 
        FROM TonKho tk
        JOIN inserted i ON tk.ma_san_pham = i.ma_san_pham;
    END;
END;

UPDATE TonKho
SET so_luong = so_luong + 10
WHERE ma_san_pham = 'NL01';

SELECT * FROM TonKho WHERE ma_san_pham = 'NL01';

-- Cập nhật hóa đơn nguyên liệu
GO
CREATE TRIGGER Trigger_CapNhatHoaDonNguyenLieu
ON HoaDon
AFTER INSERT, UPDATE
AS
BEGIN
    DELETE FROM HoaDonNguyenLieu WHERE ma_hoa_don_nguyen_lieu IN (SELECT ma_hoa_don FROM inserted);
    INSERT INTO HoaDonNguyenLieu (ma_hoa_don_nguyen_lieu, ma_nha_cung_cap, ngay, tong_tien)
    SELECT NEWID(), NCC.ma_nha_cung_cap, GETDATE(), SUM(MA.gia * CHD.so_luong)
    FROM inserted HD
    JOIN ChiTietHoaDon CHD ON HD.ma_hoa_don = CHD.ma_hoa_don
    JOIN MonAn MA ON CHD.ma_mon_an = MA.ma_mon_an
    JOIN NguyenLieu NL ON MA.ma_mon_an = NL.ma_nguyen_lieu
    JOIN NhaCungCap NCC ON NL.ma_nguyen_lieu = NCC.ma_nha_cung_cap
    GROUP BY NCC.ma_nha_cung_cap, HD.ma_hoa_don;
END;

INSERT INTO HoaDon (ma_hoa_don, ma_khach_hang, ngay, tong_tien)
VALUES ('HD12', 'KH03', '2024-05-06', 600000);

UPDATE HoaDon
SET tong_tien = 700000
WHERE ma_hoa_don = 'HD10';

SELECT * FROM HoaDon;
