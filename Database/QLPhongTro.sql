CREATE DATABASE QLPHONGTRO;
GO

USE QLPHONGTRO;
GO


/* ========         BẢNG NHANVIEN  ====*/
CREATE TABLE NHANVIEN (
    MANV INT IDENTITY(1,1) PRIMARY KEY,
    HONV NVARCHAR(50) NOT NULL,
    TENNV NVARCHAR(20) NOT NULL,
    SDT VARCHAR(15) UNIQUE,
    EMAIL VARCHAR(100) UNIQUE,
    CHUCVU NVARCHAR(50) NOT NULL
);
GO

/* ========         BẢNG KHUVUC  ====*/
CREATE TABLE KHUVUC (
    MAKV VARCHAR(5) PRIMARY KEY,
    TENKV NVARCHAR(100) NOT NULL,
    DCHI NVARCHAR(100) NOT NULL,
    MANV INT,

    CONSTRAINT FK_KHUVUC_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

/* ========         BẢNG PHONG  ====*/
CREATE TABLE PHONG (
    MAPHONG INT IDENTITY(1,1) PRIMARY KEY,
    TENPHONG NVARCHAR(50) NOT NULL,
    MAKV VARCHAR(5) NOT NULL,

    GIAPHONG DECIMAL(18,2) NOT NULL
        CHECK (GIAPHONG > 0),

    DIENTICH FLOAT
        CHECK (DIENTICH > 0),

    LOAIPHONG NVARCHAR(50) NOT NULL,

    TRANGTHAIPHONG NVARCHAR(50) NOT NULL
        CHECK (TRANGTHAIPHONG IN
        (N'Còn trống', N'Đã thuê', N'Cần ở ghép')),

    SONGUOIHIENTAI INT NOT NULL DEFAULT 0
        CHECK (SONGUOIHIENTAI >= 0),

    NOITHAT NVARCHAR(200),

    CONSTRAINT FK_PHONG_KHUVUC FOREIGN KEY (MAKV) REFERENCES KHUVUC(MAKV)
);
GO

/* ========         BẢNG KHACHTHUE  ====*/
CREATE TABLE KHACHTHUE (
    MAKH INT IDENTITY(1,1) PRIMARY KEY,

    HOKH NVARCHAR(50) NOT NULL,
    TENKH NVARCHAR(20) NOT NULL,

    NGAYSINH DATE,

    GIOITINH NVARCHAR(10)
        CHECK (GIOITINH IN (N'Nam', N'Nữ', N'Khác')),

    CCCD VARCHAR(12) NOT NULL UNIQUE,

    SDT VARCHAR(15) NOT NULL UNIQUE,

    NGAYBATDAUTHUE DATETIME NOT NULL DEFAULT GETDATE(),

    TRANGTHAITHUE NVARCHAR(50) NOT NULL
        CHECK (TRANGTHAITHUE IN
        (N'Đang thuê', N'Đã trả phòng'))
);
GO

/* ========         BẢNG TAIKHOAN  ====*/
CREATE TABLE TAIKHOAN (
    MATK VARCHAR(5) PRIMARY KEY,

    MANV INT NULL,
    MAKH INT NULL,

    TENDANGNHAP NVARCHAR(70) NOT NULL UNIQUE,

    MATKHAU VARCHAR(20) NOT NULL,

    LOAITK CHAR(2) NOT NULL
        CHECK (LOAITK IN ('NV', 'KH')),

    CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),

    CONSTRAINT FK_TAIKHOAN_KHACH FOREIGN KEY (MAKH) REFERENCES KHACHTHUE(MAKH),

    CONSTRAINT CK_TAIKHOAN_LOAI
        CHECK (
            (LOAITK = 'NV' AND MANV IS NOT NULL AND MAKH IS NULL)
            OR
            (LOAITK = 'KH' AND MAKH IS NOT NULL AND MANV IS NULL)
        )
);
GO

/* ========         BẢNG LICHHEN ====*/
CREATE TABLE LICHHEN (
    MALH INT IDENTITY(1,1) PRIMARY KEY,

    MAKH INT NOT NULL,
    MANV INT NOT NULL,
    MAPHONG INT NOT NULL,

    THOIGIANHEN DATETIME NOT NULL,

    TRANGTHAIHEN NVARCHAR(50) NOT NULL
        CHECK (TRANGTHAIHEN IN
        (N'Đã đặt', N'Đã hủy', N'Hoàn thành')),

    NOIDUNGHEN NVARCHAR(200),

    THOIGIANTAO DATETIME NOT NULL DEFAULT GETDATE(),

    THOIGIANCAPNHAT DATETIME,

    CONSTRAINT FK_LICHHEN_KHACH FOREIGN KEY (MAKH) REFERENCES KHACHTHUE(MAKH),

    CONSTRAINT FK_LICHHEN_NV FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),

    CONSTRAINT FK_LICHHEN_PHONG FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG)
);
GO

/* ========         BẢNG TINOGHEP  ====*/
CREATE TABLE TINOGHEP (
    MATINOG INT IDENTITY(1,1) PRIMARY KEY,

    MAPHONG INT NOT NULL,
    MAKH INT NOT NULL,

    SONGUOICAN INT NOT NULL
        CHECK (SONGUOICAN > 0),

    GIOITINH NVARCHAR(10) NOT NULL
        CHECK (GIOITINH IN (N'Nam', N'Nữ', N'Khác')),

    GIACHIA DECIMAL(18,2) NOT NULL
        CHECK (GIACHIA > 0),

    MOTA NVARCHAR(MAX) NOT NULL,

    TRANGTHAITIN NVARCHAR(20) NOT NULL
        CHECK (TRANGTHAITIN IN
        (N'Đang tìm', N'Đã đủ người', N'Đã đóng')),

    CONSTRAINT FK_TINOGHEP_PHONG FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG),

    CONSTRAINT FK_TINOGHEP_KHACH FOREIGN KEY (MAKH) REFERENCES KHACHTHUE(MAKH)
);
GO

/* ========         BẢNG HOPDONG ====*/
CREATE TABLE HOPDONG (
    MAHOPDONG NVARCHAR(5) PRIMARY KEY,

    MAPHONG INT NOT NULL,
    MAKH INT NOT NULL,

    NGAYKYHD DATETIME NOT NULL DEFAULT GETDATE(),

    NGAYKT DATETIME NOT NULL,

    TRANGTHAIHOPDONG NVARCHAR(50) NOT NULL
        CHECK (TRANGTHAIHOPDONG IN
        (N'Còn hiệu lực', N'Hết hiệu lực')),

    THONGTINHD NVARCHAR(200) NOT NULL,

    CONSTRAINT FK_HOPDONG_PHONG FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG),

    CONSTRAINT FK_HOPDONG_KHACH FOREIGN KEY (MAKH) REFERENCES KHACHTHUE(MAKH)
);
GO

/* ========         BẢNG HOADON  ====*/
CREATE TABLE HOADON (
    MAHOADON INT IDENTITY(1,1) PRIMARY KEY,

    MAHOPDONG NVARCHAR(5) NOT NULL,

    NGAYLAP DATETIME NOT NULL DEFAULT GETDATE(),

    TIENNUOC DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (TIENNUOC >= 0),

    TIENDIEN DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (TIENDIEN >= 0),

    TIENPHATSINH DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (TIENPHATSINH >= 0),

    TONGTIEN AS (TIENNUOC + TIENDIEN + TIENPHATSINH),

    TRANGTHAITT NVARCHAR(50) NOT NULL
        CHECK (TRANGTHAITT IN
        (N'Đã thanh toán', N'Chưa thanh toán')),

    NGAYTHANHTOAN DATETIME NULL,

    PHUONGTHUCTT NVARCHAR(50) NULL 
        CHECK (PHUONGTHUCTT IN (N'Tiền mặt', N'Chuyển khoản', N'Quét mã QR')),
    CONSTRAINT FK_HOADON_HD FOREIGN KEY (MAHOPDONG) REFERENCES HOPDONG(MAHOPDONG)
);
GO

/* ========         BẢNG BAOCAO  ====*/

CREATE TABLE BAOCAO (
    MABC INT IDENTITY(1,1) PRIMARY KEY,

    MANV INT NOT NULL,

    LOAIBC NVARCHAR(50) NOT NULL,

    NOIDUNGBC NVARCHAR(200) NOT NULL,

    THOIGIANBC DATETIME NOT NULL DEFAULT GETDATE(),
	CHECK (LOAIBC IN (N'Thống kê phòng', N'Thống kê doanh thu', N'Thống kê lịch hẹn')),
    CONSTRAINT FK_BAOCAO_NV FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

/* ======= NHANVIEN ======= */
INSERT INTO NHANVIEN (HONV, TENNV, SDT, EMAIL, CHUCVU) VALUES  
(N'Nguyễn Văn', N'Hùng', '0912345678', 'hung.nv@gmail.com', N'Quản lý'),
(N'Trần Thị', N'Hoa', '0987654321', 'hoa.tt@gmail.com', N'Nhân viên'),
(N'Lê Hoàng', N'Nam', '0933445566', 'nam.lh@gmail.com', N'Nhân viên'),
(N'Lê Nhựt', N'Đăng', '0934584566', 'dang.ln@gmail.com', N'Nhân viên'),
(N'Nguyễn Văn', N'An', '0901234567', 'an.nguyen@email.com', N'Quản lý'),
(N'Trần Thị', N'Bình', '0912345679', 'binh.tran@email.com', N'Nhân viên'),
(N'Lê Hoàng', N'Cường', '0923456789', 'cuong.le@email.com', N'Nhân viên'),
(N'Phạm Minh', N'Dũng', '0934567890', 'dung.pham@email.com', N'Nhân viên'),
(N'Hoàng Thu', N'Thảo', '0945678901', 'thao.hoang@email.com', N'Quản lý'),
(N'Vũ Tiến', N'Đạt', '0956789012', 'dat.vu@email.com', N'Nhân viên'),
(N'Phan Thanh', N'Hà', '0967890123', 'ha.phan@email.com', N'Nhân viên'),
(N'Đặng Văn', N'Hùng', '0978901234', 'hung.dang@email.com', N'Quản lý'),
(N'Bùi Thị', N'Mai', '0989012345', 'mai.bui@email.com', N'Nhân viên'),
(N'Đỗ Anh', N'Tuấn', '0990123456', 'tuan.do@email.com', N'Nhân viên');
GO

/*  ======== KHUVUC ======= */
INSERT INTO KHUVUC (MAKV, TENKV, DCHI, MANV) VALUES 
('KV001', N'Khu vực Quận 1', N'123 Nguyễn Huệ, Phường Bến Nghé, Quận 1', 2),
('KV002', N'Khu vực Bình Thạnh', N'456 Điện Biên Phủ, Phường 25, Bình Thạnh', 3),
('KV003', N'Khu vực Thủ Đức', N'789 Võ Văn Ngân, Linh Chiểu, Thủ Đức', 4);
GO

/*  ======== PHONG ======= */
INSERT INTO PHONG (TENPHONG, MAKV, GIAPHONG, DIENTICH, LOAIPHONG, TRANGTHAIPHONG, SONGUOIHIENTAI, NOITHAT) VALUES 
(N'Phòng 101', 'KV001', 5000000.00, 25.5, N'Phòng đơn cao cấp', N'Đã thuê', 1, N'Giường, tủ quần áo, máy lạnh'),
(N'Phòng 102', 'KV001', 7000000.00, 35.0, N'Phòng đôi', N'Còn trống', 0, N'Đầy đủ nội thất'),
(N'Phòng 103', 'KV001', 5500000.00, 26.0, N'Phòng đơn cao cấp', N'Đã thuê', 1, N'Giường, tủ, điều hòa, tủ lạnh'),
(N'Phòng 201', 'KV002', 4000000.00, 20.0, N'Phòng tiêu chuẩn', N'Cần ở ghép', 1, N'Giường, quạt trần'),
(N'Phòng 202', 'KV002', 4200000.00, 22.0, N'Phòng tiêu chuẩn', N'Đã thuê', 2, N'Giường đôi, quạt trần'),
(N'Phòng 301', 'KV003', 3500000.00, 18.0, N'Phòng giá rẻ', N'Đã thuê', 2, N'Trống'),
(N'Phòng 302', 'KV003', 3800000.00, 20.0, N'Phòng giá rẻ', N'Còn trống', 0, N'Trống');
GO

/*  ======== KHACHTHUE ======= */
INSERT INTO KHACHTHUE (HOKH, TENKH, NGAYSINH, GIOITINH, CCCD, SDT, NGAYBATDAUTHUE, TRANGTHAITHUE) VALUES 
(N'Phạm Minh', N'Tuấn', '2001-05-15', N'Nam', '012345678901', '0901112223', '2026-01-01', N'Đang thuê'),
(N'Lê Thị', N'Mai', '2003-08-20', N'Nữ', '012345678902', '0904445556', '2026-02-15', N'Đang thuê'),
(N'Hoàng Văn', N'Đông', '1999-11-02', N'Nam', '012345678903', '0907778889', '2025-06-01', N'Đã trả phòng'),
(N'Trần Thu', N'Hà', '1998-07-22', N'Nữ', '002098005678', '0912223334', '2025-02-15 14:00:00', N'Đang thuê'),
(N'Lê Minh', N'Khôi', '2000-11-05', N'Nam', '003200009012', '0923334445', '2025-03-01 09:15:00', N'Đã trả phòng'),
(N'Phạm Hải', N'Yến', '1993-01-28', N'Nữ', '004093003456', '0934445556', '2025-04-20 10:45:00', N'Đang thuê'),
(N'Hoàng Quốc', N'Bảo', '1997-09-14', N'Nam', '005097007890', '0945556667', '2024-12-01 16:20:00', N'Đã trả phòng'),
(N'Vũ Hồng', N'Ngọc', '2002-05-19', N'Nữ', '006202002345', '0956667778', '2025-05-05 11:00:00', N'Đang thuê'),
(N'Phan Văn', N'Đức', '1991-08-31', N'Nam', '007091006789', '0967778889', '2025-01-20 13:10:00', N'Đang thuê'),
(N'Đặng Minh', N'Anh', '1999-12-25', N'Khác', '008099001122', '0978889990', '2025-03-18 15:35:00', N'Đang thuê'),
(N'Bùi Tuyết', N'Mai', '1994-04-03', N'Nữ', '009094005566', '0989990001', '2025-02-28 17:00:00', N'Đã trả phòng'),
(N'Ngô Tiến', N'Tùng', '1996-10-10', N'Nam', '010096009900', '0990001112', GETDATE(), N'Đang thuê');
GO

/*  ======== TAIKHOAN ======= */
INSERT INTO TAIKHOAN (MATK, MANV, MAKH, TENDANGNHAP, MATKHAU, LOAITK) VALUES 
('NV001', 1, NULL, 'hung_manager', 'hung01234', 'NV'),
('NV002', 2, NULL, 'hoa_support', 'hoa01234', 'NV'),
('NV003', 3, NULL, 'AnNguyenVan', '12345678', 'NV'),
('NV004', 4, NULL, 'BinhTranThi',  '12345678', 'NV'),
('NV005', 5, NULL, 'CuongLeHoang', '12345678', 'NV');

INSERT INTO TAIKHOAN (MATK, MANV, MAKH, TENDANGNHAP, MATKHAU, LOAITK) VALUES 
('KH001', NULL, 1, 'tuan_khach', 'tuan01234', 'KH'),
('KH002', NULL, 2, 'mai_khach', 'mai01234', 'KH'),
('KH003', NULL, 3, N'0923334445', '12345678', 'KH'),
('KH004', NULL, 4, N'0934445556', '12345678', 'KH'),
('KH005', NULL, 5, N'0945556667', '12345678', 'KH'),
('KH006', NULL, 6, N'0956667778', '12345678', 'KH'),
('KH007', NULL, 7, N'0967778889', '12345678', 'KH'),
('KH008', NULL, 8, N'0978889990', '12345678', 'KH'),
('KH009', NULL, 9, N'0989990001', '12345678', 'KH'),
('KH010', NULL, 10, N'0990001112', '12345678', 'KH');
GO

/*  ======== LICHHEN ======= */
INSERT INTO LICHHEN (MAKH, MANV, MAPHONG, THOIGIANHEN, TRANGTHAIHEN, NOIDUNGHEN, THOIGIANTAO, THOIGIANCAPNHAT) VALUES 
(4, 3, 5, '2026-03-01 09:00:00', N'Hoàn thành', N'Khách xem phòng 103 và chốt ký hợp đồng luôn', '2026-02-28 14:00:00', '2026-03-01 10:30:00'),
(6, 4, 6, '2026-03-14 16:30:00', N'Hoàn thành', N'Khách xem phòng 202 khu Bình Thạnh', '2026-03-13 08:15:00', '2026-03-14 17:15:00'),
(8, 2, 3, '2026-03-28 10:00:00', N'Hoàn thành', N'Khách muốn ở ghép phòng 201', '2026-03-27 11:20:00', '2026-03-28 11:00:00');

INSERT INTO LICHHEN (MAKH, MANV, MAPHONG, THOIGIANHEN, TRANGTHAIHEN, NOIDUNGHEN, THOIGIANTAO, THOIGIANCAPNHAT) VALUES 
(5, 3, 2, '2026-04-10 14:00:00', N'Đã hủy', N'Khách báo bận đột xuất, hẹn dịp khác', '2026-04-09 15:30:00', '2026-04-10 11:00:00'),
(9, 4, 1, '2026-05-02 09:30:00', N'Đã hủy', N'Phòng 101 đã được thuê trước khi khách đến xem', '2026-05-01 16:00:00', '2026-05-02 08:00:00');

INSERT INTO LICHHEN (MAKH, MANV, MAPHONG, THOIGIANHEN, TRANGTHAIHEN, NOIDUNGHEN, THOIGIANTAO, THOIGIANCAPNHAT) VALUES 
(10, 2, 2, '2026-05-26 10:00:00', N'Đã đặt', N'Dẫn khách xem phòng đôi 102 Quận 1', GETDATE(), NULL),
(11, 3, 7, '2026-05-28 15:30:00', N'Đã đặt', N'Khách muốn xem phòng trống mới 302 Thủ Đức', GETDATE(), NULL),
(12, 4, 3, '2026-05-30 09:00:00', N'Đã đặt', N'Khách xem phòng 201 để tìm người ở ghép', GETDATE(), NULL),
(3,  2, 2, '2026-06-02 14:00:00', N'Đã đặt', N'Khách cũ muốn xem phòng đổi sang phòng rộng hơn', GETDATE(), NULL),
(7,  3, 6, '2026-06-05 16:00:00', N'Đã đặt', N'Hẹn khách bàn giao lại phòng 202 thanh lý hợp đồng', GETDATE(), NULL);
GO
GO

/*  ======== TINOGHEP ======= */
INSERT INTO TINOGHEP (MAPHONG, MAKH, SONGUOICAN, GIOITINH, GIACHIA, MOTA, TRANGTHAITIN) VALUES 
(3, 2, 1, N'Nữ', 2000000.00, N'Tìm bạn nữ ở ghép, sạch sẽ, không chung chủ.', N'Đang tìm');
GO

/*  ======== HOPDONG ======= */
INSERT INTO HOPDONG (MAHOPDONG, MAPHONG, MAKH, NGAYKYHD, NGAYKT, TRANGTHAIHOPDONG, THONGTINHD) VALUES 
('HD001', 2, 1, '2026-01-01', '2027-01-01', N'Còn hiệu lực', N'Hợp đồng thuê phòng 101 hạn 1 năm'),
('HD002', 4, 2, '2026-02-15', '2026-08-15', N'Còn hiệu lực', N'Hợp đồng ngắn hạn 6 tháng'),
('HD003', 5, 4, '2026-03-01', '2027-03-01', N'Còn hiệu lực', N'Hợp đồng thuê phòng 103 - Cọc 1 tháng'),
('HD004', 6, 6, '2026-03-15', '2026-09-15', N'Còn hiệu lực', N'Hợp đồng phòng 202 hạn 6 tháng'),
('HD005', 3, 8, '2026-04-01', '2026-10-01', N'Còn hiệu lực', N'Hợp đồng ở ghép phòng 201');
GO

/*  ======== HOADON ======= */
INSERT INTO HOADON (MAHOPDONG, NGAYLAP, TIENNUOC, TIENDIEN, TIENPHATSINH, TRANGTHAITT, NGAYTHANHTOAN, PHUONGTHUCTT) VALUES 
('HD001', '2026-03-01', 120000.00, 380000.00, 50000.00, N'Đã thanh toán', '2026-03-04', N'Chuyển khoản'),
('HD002', '2026-03-05', 90000.00,  280000.00, 0.00,     N'Đã thanh toán', '2026-03-05', N'Tiền mặt');

INSERT INTO HOADON (MAHOPDONG, NGAYLAP, TIENNUOC, TIENDIEN, TIENPHATSINH, TRANGTHAITT, NGAYTHANHTOAN, PHUONGTHUCTT) VALUES 
('HD001', '2026-04-01', 130000.00, 410000.00, 0.00,     N'Đã thanh toán', '2026-04-05', N'Quét mã QR'),
('HD002', '2026-04-05', 95000.00,  310000.00, 0.00,     N'Đã thanh toán', '2026-04-06', N'Chuyển khoản'),
('HD003', '2026-04-05', 150000.00, 520000.00, 100000.00,N'Đã thanh toán', '2026-04-07', N'Chuyển khoản'),
('HD004', '2026-04-15', 180000.00, 490000.00, 0.00,     N'Đã thanh toán', '2026-04-17', N'Quét mã QR');

INSERT INTO HOADON (MAHOPDONG, NGAYLAP, TIENNUOC, TIENDIEN, TIENPHATSINH, TRANGTHAITT, NGAYTHANHTOAN, PHUONGTHUCTT) VALUES 
('HD001', '2026-05-01', 150000.00, 450000.00, 0.00, N'Đã thanh toán','2026-05-05', N'Chuyển khoản'),
('HD002', '2026-05-05', 100000.00, 300000.00, 0.00, N'Đã thanh toán','2026-05-09', N'Tiền mặt'),
('HD003', '2026-05-05', 160000.00, 580000.00, 0.00,     N'Đã thanh toán', '2026-05-08', N'Chuyển khoản'),
('HD004', '2026-05-15', 190000.00, 510000.00, 30000.00, N'Chưa thanh toán', NULL, NULL),
('HD005', '2026-05-15', 80000.00,  220000.00, 0.00,     N'Chưa thanh toán', NULL, NULL);
GO

/*  ======== BAOCAO ======= */
INSERT INTO BAOCAO (MANV, LOAIBC, NOIDUNGBC, THOIGIANBC) VALUES 
(1, N'Thống kê doanh thu', N'Báo cáo doanh thu tháng 04/2026: Tổng thu 12,500,000 VND, đạt 95% chỉ tiêu.', '2026-05-01 08:30:00'),
(2, N'Thống kê phòng', N'Báo cáo tình trạng phòng: 2 phòng đã thuê, 1 phòng trống, 1 phòng đang tìm người ở ghép.', '2026-05-15 17:00:00'),
(1, N'Thống kê lịch hẹn', N'Thống kê lịch hẹn tuần 2 tháng 5: Tổng 5 lịch hẹn, 4 hoàn thành, 1 đã hủy.', '2026-05-18 10:15:00'),
(2, N'Thống kê doanh thu', N'Báo cáo phát sinh tiền điện nước vượt mức trung bình tại Khu vực Bình Thạnh (KV002).', GETDATE());
GO