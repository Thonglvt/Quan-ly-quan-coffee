CREATE DATABASE QL_QuanCafeUpdate
GO
USE QL_QuanCafeUpdate
GO
CREATE TABLE tblBan
(
	MaBan nvarchar(100),
	TenBan nvarchar(200),
	SoCho int,
	TrangThai bit,				--1:có khách, 0:trống

	CONSTRAINT PK_tblBan PRIMARY KEY (MaBan)
)
GO
CREATE TABLE tblNhomSP
(
	MaNhomSP nvarchar(100),
	TenNhomSP nvarchar(200),

	CONSTRAINT PK_tblNhomSP PRIMARY KEY (MaNhomSP)
)
GO
CREATE TABLE tblNhaCungCap
(
	MaNCC nvarchar(100),
	TenNCC nvarchar(200),
	DiaChi nvarchar(500),
	SDT nvarchar(50),
	Email nvarchar(100),

	CONSTRAINT PK_tblNhaCungCap PRIMARY KEY (MaNCC)
)
GO
CREATE TABLE tblHangHoa
(
	MaHH nvarchar(100),
	TenHH nvarchar(200),
	DVT nvarchar(100),

	CONSTRAINT PK_tblHangHoa PRIMARY KEY (MaHH)
)
GO
CREATE TABLE tblPhieuNhap
(
	MaPN nvarchar(100),
	NgayLap nvarchar(200),
	TongTienNhap float,
	MaNCC nvarchar(100),

	CONSTRAINT PK_tblPhieuNhap PRIMARY KEY (MaPN)
)
GO
CREATE TABLE tblCTPhieuNhap
(
	MaPN nvarchar(100),
	MaHH nvarchar(100),
	SoLuong int,
	DonGiaNhap float,

	CONSTRAINT PK_tblCTPhieuNhap PRIMARY KEY (MaPN,MaHH)
)
GO
CREATE TABLE tblNhanVien
(
	MaNV nvarchar(100),
	TenNV nvarchar(100),
	NgaySinh date,
	GioiTinh nvarchar(10),
	DiaChi nvarchar(500),
	SDT nvarchar(20),
	CCCD nvarchar(20),
	ChucVu int,
	NgayVaoLam Datetime,
	TaiKhoan varchar(100),
	MatKhau varchar(100),
	TrangThai bit,

	CONSTRAINT PK_tblNhanVien PRIMARY KEY (MaNV)
)
GO
CREATE TABLE tblKhachHang
(
	MaKH nvarchar(100),
	TenKH nvarchar(100),
	GioITinh nvarchar(10),
	SDT nvarchar(20),

	CONSTRAINT PK_tblKhachHang PRIMARY KEY (MaKH)
)
GO
CREATE TABLE tblSanPham
(
	MaSP int identity(1,1),
	TenSP nvarchar(200),
	Hinh nvarchar(500),
	MaNhomSP nvarchar(100),
	TrangThai bit,

	CONSTRAINT PK_tblSanPham PRIMARY KEY (MaSP)
)
GO
CREATE TABLE tblSize
(
	MaSize nvarchar(100),
	TenSize nvarchar(200),
	MoTa nvarchar(600),

	CONSTRAINT PK_tblSize PRIMARY KEY (MaSize)
)
GO
CREATE TABLE tblBangGia
(
	MaBangGia int identity(1,1),
	MaSP int,
	MaSize nvarchar(100),
	Gia float,
	NgayCapNhat datetime,

	CONSTRAINT PK_tblBangGia PRIMARY KEY (MaBangGia)
)
GO
CREATE TABLE tblHoaDonBanHang
(
	MaHD nvarchar(100),
	MaNV nvarchar(100),
	MaKH nvarchar(100),
	MaBan nvarchar(100),
	NgayLap Datetime default getdate(),
	PhuThu int default 0,
	GiamGia int default 0,
	TongTien float default 0,
	TrangThai bit,							--0: Chưa thanh toán, 1: đã thanh toán

	CONSTRAINT PK_tblHoaDonBanHang PRIMARY KEY (MaHD)
)
GO
CREATE TABLE tblChiTietHD
(
	MaHD nvarchar(100),
	MaBangGia int,
	SoLuong int,
	DonGia float,
	ThanhTien float,

	CONSTRAINT PK_tblChiTietHD PRIMARY KEY (MaHD,MaBangGia)
)
GO
go
Create table tblCaLamViec
(
	MaCa Varchar(100),
	TenCa nVarchar(500),
	GioBD nvarchar(100),							--Giờ bắt đầu của ca
	GioKT nvarchar(100),							--Giờ kết thúc của ca
	SoTien decimal,									--Số tiền trong ca đó
	CONSTRAINT PK_tblCaLamViec PRIMARY KEY (MaCa)
)
go
Create table tblDangKyCa							--Dành cho nhân viên khi đăng ký ca làm việc
(
	MaDKCa int identity(1,1),	
	MaCa Varchar(100),								--Thuộc ca nào
	MaNV nvarchar(100),								--Nhân viên nào đky ca
	NgayDKCa datetime default getdate(),			--Ngày đky ca

	CONSTRAINT PK_tblDangKyCa PRIMARY KEY (MaDKCa)
)
go
Create table tblChamCong							--Dành cho quản lý chấm công nhân viên trong ca
(		
	MaChamCong Varchar(100),											
	Thang int,										--Tháng
	Nam int,										--Năm
	TrangThai bit default 0,						--1: Khóa, 2:Mở
	CONSTRAINT PK_tblChamCong PRIMARY KEY (MaChamCong)
)	
go
Create table tblChiTietChamCong
(
	MaChamCong Varchar(100),						--Mã chấm công
	MaDKCa int,										--Mã đk ca
	--MaNV varchar(1000),							--Nhân Viên được chấm công

	--Từ ngày 1 đến ngày 31
	Ngay1 nvarchar(100) default 'X',Ngay2 nvarchar(100) default 'X',Ngay3 nvarchar(100) default 'X',Ngay4 nvarchar(100) default 'X',Ngay5 nvarchar(100) default 'X',
	Ngay6 nvarchar(100) default 'X',Ngay7 nvarchar(100) default 'X',Ngay8 nvarchar(100) default 'X',Ngay9 nvarchar(100) default 'X',Ngay10 nvarchar(100) default 'X',
	Ngay11 nvarchar(100) default 'X',Ngay12 nvarchar(100) default 'X',Ngay13 nvarchar(100) default 'X',Ngay14 nvarchar(100) default 'X',Ngay15 nvarchar(100) default 'X',
	Ngay16 nvarchar(100) default 'X',Ngay17 nvarchar(100) default 'X',Ngay18 nvarchar(100) default 'X',Ngay19 nvarchar(100) default 'X',Ngay20 nvarchar(100) default 'X',
	Ngay21 nvarchar(100) default 'X',Ngay22 nvarchar(100) default 'X',Ngay23 nvarchar(100) default 'X',Ngay24 nvarchar(100) default 'X',Ngay25 nvarchar(100) default 'X',
	Ngay26 nvarchar(100) default 'X',Ngay27 nvarchar(100) default 'X',Ngay28 nvarchar(100) default 'X',Ngay29 nvarchar(100) default 'X',Ngay30 nvarchar(100) default 'X',
	Ngay31 nvarchar(100) default 'X',
	-- 0(false): vắng, 1(true):có làm việc

	CONSTRAINT PK_tblChiTietChamCong PRIMARY KEY (MaChamCong,MaDKCa)
)

--------
Alter table tblSanPham add CONSTRAINT FK_tblSanPham_tblNhomSP FOREIGN KEY (MaNhomSP) REFERENCES tblNhomSP(MaNhomSP)
--
Alter table tblDangKyCa add CONSTRAINT FK_tblDangKyCa_tblCaLamViec FOREIGN KEY (MaCa) REFERENCES tblCaLamViec(MaCa)
Alter table tblDangKyCa add CONSTRAINT FK_tblDangKyCa_tblNhanVien FOREIGN KEY (MaNV) REFERENCES tblNhanVien(MaNV)
--
Alter table tblChiTietChamCong add CONSTRAINT FK_tblChiTietChamCong_tblChamCong FOREIGN KEY (MaChamCong) REFERENCES tblChamCong(MaChamCong)
Alter table tblChiTietChamCong add CONSTRAINT FK_tblChiTietChamCong_tblDangKyCa FOREIGN KEY (MaDKCa) REFERENCES tblDangKyCa(MaDKCa)
--
Alter table tblPhieuNhap add CONSTRAINT FK_tblPhieuNhap_tblNhaCungCap FOREIGN KEY (MaNCC) REFERENCES tblNhaCungCap(MaNCC)
--
Alter table tblCTPhieuNhap add CONSTRAINT FK_tblCTPhieuNhap_tblPhieuNhap FOREIGN KEY (MaPN) REFERENCES tblPhieuNhap(MaPN)
Alter table tblCTPhieuNhap add CONSTRAINT FK_tblCTPhieuNhap_tblHangHoa FOREIGN KEY (MaHH) REFERENCES tblHangHoa(MaHH)
--
Alter table tblBangGia add CONSTRAINT FK_tblBangGia_tblSanPham FOREIGN KEY (MaSP) REFERENCES tblSanPham(MaSP)
Alter table tblBangGia add CONSTRAINT FK_tblBangGia_tblSize FOREIGN KEY (MaSize) REFERENCES tblSize(MaSize)
--
Alter table tblHoaDonBanHang add CONSTRAINT FK_tblHoaDonBanHang_tblNhanVien FOREIGN KEY (MaNV) REFERENCES tblNhanVien(MaNV)
Alter table tblHoaDonBanHang add CONSTRAINT FK_tblHoaDonBanHang_tblKhachHang FOREIGN KEY (MaKH) REFERENCES tblKhachHang(MaKH)
Alter table tblHoaDonBanHang add CONSTRAINT FK_tblHoaDonBanHang_tblBan FOREIGN KEY (MaBan) REFERENCES tblBan(MaBan)
--
Alter table tblChiTietHD add CONSTRAINT FK_tblChiTietHD_tblHoaDonBanHang FOREIGN KEY (MaHD) REFERENCES tblHoaDonBanHang(MaHD)
Alter table tblChiTietHD add CONSTRAINT FK_tblChiTietHD_tblBangGia FOREIGN KEY (MaBangGia) REFERENCES tblBangGia(MaBangGia)

---------------------DATA---------------
INSERT INTO tblBan VALUES ('BAN1','Bàn 1',4,0)
INSERT INTO tblBan VALUES ('BAN2','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN3','Bàn 3',4,0)
INSERT INTO tblBan VALUES ('BAN4','Bàn 4',4,0)
INSERT INTO tblBan VALUES ('BAN5','Bàn 5',4,0)
INSERT INTO tblBan VALUES ('BAN6','Bàn 6',4,0)
INSERT INTO tblBan VALUES ('BAN7','Bàn 7',4,0)
INSERT INTO tblBan VALUES ('BAN8','Bàn 8',4,0)
INSERT INTO tblBan VALUES ('BAN9','Bàn 9',4,0)
INSERT INTO tblBan VALUES ('BAN10','Bàn 10',4,0)
INSERT INTO tblBan VALUES ('BAN11','Bàn 11',4,0)
INSERT INTO tblBan VALUES ('BAN12','Bàn 12',4,0)
INSERT INTO tblBan VALUES ('BAN13','Bàn 13',4,0)
INSERT INTO tblBan VALUES ('BAN14','Bàn 14',4,0)
INSERT INTO tblBan VALUES ('BAN15','Bàn 15',4,0)
INSERT INTO tblBan VALUES ('BAN16','Bàn 16',4,0)
INSERT INTO tblBan VALUES ('BAN17','Bàn 17',4,0)
INSERT INTO tblBan VALUES ('BAN18','Bàn 18',4,0)
INSERT INTO tblBan VALUES ('BAN19','Bàn 19',4,0)
INSERT INTO tblBan VALUES ('BAN20','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN21','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN22','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN23','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN24','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN25','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN26','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN27','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN28','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN29','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN30','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN31','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN32','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN33','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN34','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN35','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN36','Bàn 2',4,0)
INSERT INTO tblBan VALUES ('BAN37','Bàn 2',4,0)


--
INSERT INTO tblNhanVien VALUES('06062022NV000001',N'Lê Văn Thông','10-02-2001',N'Nam',N'114 Lũy Bán Bích, P.Tân Thới Hòa, Q.Tân Phú, TP.HCM'
,'0396210106','212845009',1,getdate(),'admin','admin',1)
---
INSERT INTO tblKhachHang VALUES('06062022KH000001',N'Khách lẻ',N'Nam','')
----
INSERT INTO tblNhomSP VALUES('COFFE',N'Coffe')
INSERT INTO tblNhomSP VALUES('TRASUA',N'Trà sữa')
INSERT INTO tblNhomSP VALUES('SINHTO',N'Sinh tố')
INSERT INTO tblNhomSP VALUES('NATCHA',N'Matcha')
INSERT INTO tblNhomSP VALUES('NUOCEP',N'Nước ép')
INSERT INTO tblNhomSP VALUES('SODA',N'Soda')
INSERT INTO tblNhomSP VALUES('NUOCNGOT',N'Nước ngọt')
INSERT INTO tblNhomSP VALUES('BINGSU',N'Bingsu')

--------
INSERT INTO tblSize VALUES('M',N'Size M',N'Size M cho những người kém uống hichic')
INSERT INTO tblSize VALUES('L',N'Size L',N'Size L cho những người béo')
INSERT INTO tblSize VALUES('XL',N'Size XL',N'Size XL dành riêng cho người gần cực béo')
INSERT INTO tblSize VALUES('XXL',N'Size XXL',N'Size XXL dành riêng cho người cực béo')
INSERT INTO tblSize VALUES('NOSIZE',N'No size',N'Một size thôi bạn')
--------
--SAN PHAM
INSERT INTO tblSanPham VALUES(N'Coffee đen','',1,'COFFE')
INSERT INTO tblSanPham VALUES(N'Coffee sữa','',1,'COFFE')
INSERT INTO tblSanPham VALUES(N'Bạc xỉu 3 tầng','',1,'COFFE')
INSERT INTO tblSanPham VALUES(N'Ca cao sữa','',1,'COFFE')
INSERT INTO tblSanPham VALUES(N'Sữa tươi cafe','',1,'COFFE')
INSERT INTO tblSanPham VALUES(N'Coffee cốt dừa','',1,'COFFE')

--INSERT INTO tblSanPham VALUES(N'Trà sữa hope','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà xanh sữa','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa dâu','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa xoài','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa thanh long đỏ','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa Olong','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa bá tước','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa Hokaido','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa khoai môn','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa matcha','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa cake cream','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa oreo cake cream','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa socola oreo cake cream','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa matcha cake cream','',1,'TRASUA')
INSERT INTO tblSanPham VALUES(N'Trà sữa Macchiato','',1,'TRASUA')
--
INSERT INTO tblSanPham VALUES(N'Bingsu thập cẩm','',1,'BINGSU')
INSERT INTO tblSanPham VALUES(N'Bingsu dâu','',1,'BINGSU')
INSERT INTO tblSanPham VALUES(N'Bingsu đào','',1,'BINGSU')
INSERT INTO tblSanPham VALUES(N'Bingsu xoài','',1,'BINGSU')
INSERT INTO tblSanPham VALUES(N'Bingsu dưa hấu','',1,'BINGSU')
INSERT INTO tblSanPham VALUES(N'Bingsu Matcha','',1,'BINGSU')
INSERT INTO tblSanPham VALUES(N'Bingsu Socola cookie','',1,'BINGSU')
----BẢNG GIÁ
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(1,'NOSIZE',14000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(2,'NOSIZE',16000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(3,'NOSIZE',18000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(4,'NOSIZE',22000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(5,'NOSIZE',18000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(6,'NOSIZE',32000,GETDATE())
--
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(7,'NOSIZE',18000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(8,'NOSIZE',18000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(9,'NOSIZE',20000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(10,'NOSIZE',22000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(11,'NOSIZE',22000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(12,'NOSIZE',20000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(13,'NOSIZE',22000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(14,'NOSIZE',22000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(15,'NOSIZE',20000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(16,'NOSIZE',23000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(17,'NOSIZE',22000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(18,'NOSIZE',26000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(19,'NOSIZE',24000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(20,'NOSIZE',27000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(21,'NOSIZE',24000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(22,'M',35000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(22,'l',70000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(23,'M',35000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(23,'L',70000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(24,'M',32000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(24,'L',60000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(25,'M',32000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(25,'L',60000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(26,'M',32000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(26,'L',60000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(27,'M',32000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(27,'L',60000,GETDATE())

INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(28,'M',32000,GETDATE())
INSERT INTO tblBangGia(MaSP,MaSize,Gia,NgayCapNhat) VALUES(28,'L',60000,GETDATE())






------------------------TRIGGER------------------------------
----------Tự động cập nhật 1:đơn giá 2:Thành tiền trên tblCTHD, Tổng tiền trên bảng HD khi thêm tblCTHD
Go
CREATE TRIGGER tg_AutoUpdDonGia_ThanhTien_CTHD_HD on tblChiTIetHD
for insert,update
as
	--1:Cập nhật đơn giá
	update tblChiTietHD
	set DonGia = (select b.Gia 
					from tblBangGia b 
					where b.MaBangGia = (Select MaBangGia from inserted))
	where MaHD = (Select MaHD from inserted) and MaBangGia = (Select MaBangGia from inserted)

	--2:Cập nhật thành tiền
	update tblChiTietHD
	set ThanhTien = SoLuong * DonGia
	where MaHD = (Select MaHD from inserted) and MaBangGia = (Select MaBangGia from inserted)

	--3:Cập nhật tổng tiền trên tblHoaDonBanHang( TongTien = sum(thanhTien))
	update tblHoaDonBanHang
	set TongTien = (Select sum(ThanhTien) from tblChiTietHD where MaHD = (Select MaHD from inserted))
	where MaHD = (Select MaHD from inserted)

	--4:Cap nhat Tổng tiền khi có phụ thu
	update tblHoaDonBanHang
	set TongTien = TongTien + ((TongTien*PhuThu)/100)
	where MaHD = (Select MaHD from inserted)

	--5:Cap nhat Tổng tiền khi có giảm giá
	update tblHoaDonBanHang
	set TongTien = TongTien - ((TongTien*GiamGia)/100)
	where MaHD = (Select MaHD from inserted)
go


























