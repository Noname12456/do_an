﻿Create database QL_NhaSach

Create table QUYEN (
IDQUYEN int IDENTITY Primary key,
MAQUYEN nchar(255),
TenQuyen nvarchar(255),
disabled int DEFAULT '0',
)
Create table LOAIQUYEN (
IDLOAIQUYEN int IDENTITY Primary key,
MALOAIQUYEN nchar(255),
TenLoaiQuyen nvarchar(255),
disabled int DEFAULT '0',
)
Create table LOAIQUYENOFQUYEN (
IDQUYEN int,
IDLOAIQUYEN int,
disabled int DEFAULT '0',
CONSTRAINT pk_LOAIQUYENOFQUYEN PRIMARY KEY(IDQUYEN,IDLOAIQUYEN),
CONSTRAINT FK_LOAIQUYENOFQUYEN_QUYEN FOREIGN KEY (IDQUYEN) REFERENCES QUYEN(IDQUYEN),
CONSTRAINT FK_LOAIQUYENOFQUYEN_LOAIQUYEN  FOREIGN KEY (IDLOAIQUYEN) REFERENCES LOAIQUYEN(IDLOAIQUYEN),
)

Create table CHINHANH(
MACN nchar(10) primary key,
TENCN NVARCHAR(500),
DC NVARCHAR(500),
STK NVARCHAR(20),
SDT NVARCHAR(10),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
)
Create table NHANVIEN(
MANV nvarchar(10) Primary key,
TENNV nvarchar(255),
DC nvarchar(255),
EMAIL nvarchar(255),
SDT nvarchar(255),
NGAYSINH date,
disabled int DEFAULT '0',
MATKHAU nvarchar(255),
MACN Nchar(10),
IDQUYEN int,
CONSTRAINT fk_CN_QUYEN FOREIGN KEY (IDQUYEN) REFERENCES QUYEN(IDQUYEN),
CONSTRAINT fk_CN_NHANVIEN FOREIGN KEY (MACN) REFERENCES CHINHANH(MACN),
) 
alter table NHANVIEN ADD 
NGUOITAO nvarchar(10)
alter table NHANVIEN ADD  NGAYTAO Date DEFAULT getdate()
alter table NHANVIEN ADD  NGUOISUA nvarchar(10)
alter table NHANVIEN ADD NGAYSUA Date
alter table NHANVIEN ADD CONSTRAINT fk_NV_Tao FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV)
alter table NHANVIEN ADD   CONSTRAINT fk_NV_SUA FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
alter table CHINHANH add CONSTRAINT fk_CHINHANH_KHNGT FOREIGN KEY (NGUOITAO)REFERENCES NHANVIEN(MANV)
alter table CHINHANH add  CONSTRAINT fk_CHINHANH_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)

Create table LOAIQUYENOFNHANVIEN(
MANV nvarchar(10),
IDLOAIQUYEN int,
disabled int DEFAULT '0',
CONSTRAINT pk_LOAIQUYENOFNHANVIEN PRIMARY KEY(MANV,IDLOAIQUYEN),
CONSTRAINT FK_LOAIQUYENOFNHANVIEN_NHANVIEN  FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
CONSTRAINT FK_LOAIQUYENOFNHANVIEN_LOAIQUYEN  FOREIGN KEY (IDLOAIQUYEN) REFERENCES LOAIQUYEN(IDLOAIQUYEN),
)

Create table MATHANG (
MAMH nchar(10) primary key,
TENMATHANG NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_MH_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_MH_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)

Create table LOAIMATHANG (
MALOAI nchar(10) primary key,
TENLOAI NVARCHAR(500),
HINHMINHHOA NVARCHAR(255),
MAMH nchar (10),
disabled int DEFAULT '0',
CONSTRAINT fk_MH_LMH FOREIGN KEY (MAMH) REFERENCES MATHANG(MAMH ),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_LOAIMATHANG_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_LOAIMATHANG_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table CHUDE (
MACD nchar(10) primary key,
TENCD NVARCHAR(500),
HINHMINHHOA NVARCHAR(255),
MALOAI nchar (10),
disabled int DEFAULT '0',
CONSTRAINT fk_CD_LMH
  FOREIGN KEY (MALOAI )
  REFERENCES LOAIMATHANG (MALOAI ),
  NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_CD_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_CD_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)

Create table LOAICHUDE (
MALOAICD nchar(10) primary key,
TENLOAICD NVARCHAR(500),
HINHMINHHOA NVARCHAR(255),
MACD nchar (10),
disabled int DEFAULT '0',
CONSTRAINT fk_LOAICD_CD FOREIGN KEY (MACD ) REFERENCES CHUDE (MACD ),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_LOAICD_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_LOAICD_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)

Create table TACGIA (
MATG nchar(10) primary key,
TENTG NVARCHAR(500),
NGAYSINH DATE,
DC NVARCHAR(500),
SDT NVARCHAR(10),
EMAIL NVARCHAR(50),
GT NVARCHAR(3),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_TG_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_TG_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)

Create table NHACC(
MANCC nchar(10) primary key,
TENCC NVARCHAR(500),
DC NVARCHAR(500),
STK NVARCHAR(20),
SDT NVARCHAR(10),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_NCC_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_NCC_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table NHAXB(
MANXB nchar(10) primary key,
TENNXB NVARCHAR(500),
DC NVARCHAR(500),
STK NVARCHAR(20),
SDT NVARCHAR(10),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_NHAXB_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_NXB_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table SANPHAM(
MASP NCHAR(10) PRIMARY KEY,
TENSP NVARCHAR(500),
NGAYDANG DATE,
GIABAN INT,
GIANHAP INT,
MANCC NCHAR(10),
MANXB NCHAR(10),
XUATXU NVARCHAR(500),
THUONGHIEU NVARCHAR(500),
NGONNGU NVARCHAR(500),
KICHTHUOC NVARCHAR(500),
SOTRANG NVARCHAR(500),
MOTA NVARCHAR(500),
DOTUOI NVARCHAR(500),
HSD DATE,
SLTON INT,
TRONGLUONG INT,
disabled int DEFAULT '0'
CONSTRAINT fk_MANCC_SP FOREIGN KEY (MANCC ) REFERENCES NHACC (MANCC),
CONSTRAINT fk_MANXB_SP FOREIGN KEY (MANXB) REFERENCES NHAXB (MANXB),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SP_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_SP_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
  )
    
CREATE table SACHTG(
MASP NCHAR(10),
MATG NCHAR(10),
CONSTRAINT pk_SACHTG PRIMARY KEY(MASP,MATG),
CONSTRAINT fk_SACHTG_SP FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
CONSTRAINT fk_SACHTG_TG FOREIGN KEY (MATG) REFERENCES TACGIA (MATG),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SCAHTG_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_SACHTG_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)

CREATE table SANPHAMHINHANH(
MAHINH int IDENTITY Primary key,
MASP nchar(10),
HINH nvarchar(255),
CONSTRAINT fk_SANPHAMHINHANH_SP FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SPHINH_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_SPHINH_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table SANPHAMLOAICHUDE(
MASP nchar(10),
MALOAICD nchar(10),
disabled int DEFAULT '0',
CONSTRAINT pk_SANPHAMLOAICHUDE PRIMARY KEY(MASP,MALOAICD),
CONSTRAINT fk_SANPHAMLOAICHUDE_SP FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
CONSTRAINT fk_SANPHAMLOAICHUDE_LOAICD FOREIGN KEY (MALOAICD) REFERENCES LOAICHUDE (MALOAICD),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SPCD_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_SPCD_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
CREATE table SANPHAMCN(
MASP NCHAR(10),
MACN NCHAR(10),
CONSTRAINT pk_SANPHAMCN PRIMARY KEY(MASP,MACN),
CONSTRAINT fk_SANPHAMCN_SP FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
CONSTRAINT fk_CN_SP FOREIGN KEY (MACN) REFERENCES CHINHANH (MACN),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
SLTON INT DEFAULT '0',
CONSTRAINT fk_SANPHAMCN_KHNGT FOREIGN KEY (NGUOITAO)REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_SANPHAMCN_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table KHACHHANG(
MAKH int IDENTITY Primary key,
HOKH nvarchar(255),
TENKH nvarchar(255),
DC nvarchar(255),
EMAIL nvarchar(255),
SDT nvarchar(10),
disabled int DEFAULT '0',
MATKHAU nvarchar(255),
)

Create table DANHGIA(
MADG int IDENTITY Primary key,
MASP nchar(10),
MAKH int,
NGAYDANHGIA date,
DIEMDANHGIA int,
CONSTRAINT fk_DANHGIA_SP FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
CONSTRAINT fk_DANHGIA_KH FOREIGN KEY (MAKH) REFERENCES KHACHHANG (MAKH),
)
Create table KHUYENMAI(
MAKHM Nchar(10) primary key,
GIATIEN int,
NGAYBD Date,
NGAYKET Date,
DIEUKIEN int,
HINHTHUCKM int,
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
disabled int DEFAULT '0',
CONSTRAINT fk_KM_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_KM_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table DONHANG(
MADH int IDENTITY Primary key,
NGAYLAP date DEFAULT getdate(),
TONGTIEN int DEFAULT 0,
DCGIAO nvarchar(255),
SDT nvarchar(255),
QUOCGIA nvarchar(255),
THANHPHO nvarchar(255),
QUANHUYEN nvarchar(255),
PHUONGXA nvarchar(255),
EMAIL nvarchar(255),
HINHTHUC int,
TRANGTHAI int DEFAULT 0,
MAKH int DEFAULT NULL,
MAKHM nchar(10) NULL,
MACN nchar(10) NULL,
HOTEN nvarchar(255),
DIACHI nvarchar(255),
CONSTRAINT fk_DONHANG_KH FOREIGN KEY (MAKH) REFERENCES KHACHHANG (MAKH),
CONSTRAINT fk_DONHANG_CN FOREIGN KEY (MACN) REFERENCES CHINHANH (MACN),
CONSTRAINT fk_DONHANG_KM FOREIGN KEY (MAKHM) REFERENCES KHUYENMAI (MAKHM),
)
alter table donhang
add TIENGIAM INT  DEFAULT 0
Create table DONHANGCT(
MADH int,
MASP nchar(10),
SL int,
THANHTIEN int DEFAULT 0,
CONSTRAINT pk_DONHANGCT PRIMARY KEY(MADH,MASP),
CONSTRAINT fk_DONGHANGCT_DONHANG FOREIGN KEY (MADH) REFERENCES DONHANG (MADH),
CONSTRAINT fk_DONHANGCT_SP FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
)
Create table QUANGCAO(
MA int IDENTITY Primary key,
Hinh nvarchar(255),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_QUANGCAO_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_QUANGCAO_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
Create table NHACCNHAP(
MANCC nchar(10) primary key,
TENCC NVARCHAR(500),
DC NVARCHAR(500),
STK NVARCHAR(20),
SDT NVARCHAR(10),
MOTA NVARCHAR(500),
KYHIEUHD NVARCHAR(500),
KYHIEUMAUDH NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_NCCNHAP_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_NCCNHAP_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
)
create table PHIEUNHAP(
MAPHIEU int IDENTITY Primary key,
SOHD nchar(10),
KYHIEUHD NVARCHAR(500),
KYHIEUMAUDH NVARCHAR(500),
NGAYNHAP date,
NGAYHD date,
NGAYNHANHD date,
MACN nchar(10),
TONG float,
VAT float,
TIENVAT float,
THANHTIENVAT float,
GHICHU nvarchar(500),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
TRANGTHAI int DEFAULT 0,
NGAYSUA Date,
MANCC nchar(10),
CONSTRAINT fk_PN_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_PN_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV),
CONSTRAINT fk_CN_PHIEUNHAP FOREIGN KEY (MACN) REFERENCES CHINHANH(MACN),
CONSTRAINT fk_CN_PHIEUNHAPNCC FOREIGN KEY (MANCC) REFERENCES NHACCNHAP(MANCC),
)
create table PHIEUNHAPCT(
MAPHIEU int,
MASP NCHAR(10),
SL INT,
THANHTIEN float,
THANHTIENVAT float,
DONGIA float,
DONGIAVAT float,
disabled int DEFAULT '0',
CONSTRAINT pk_PHIEUNHAPCT PRIMARY KEY(MAPHIEU,MASP),
CONSTRAINT fk_PNCT_KHNGT FOREIGN KEY (MAPHIEU) REFERENCES PHIEUNHAP(MAPHIEU),
CONSTRAINT fk_PNCT_KHNGS FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP),
)
--ADD admin
INSERT INTO NHANVIEN(MANV,TENNV,MATKHAU) VALUES ('admin','Admin','123')
--Add mặt hàng
INSERT INTO MATHANG(MAMH,TENMATHANG,NGUOITAO) VALUES ('MH001',N'SACH','admin')
INSERT INTO MATHANG(MAMH,TENMATHANG,NGUOITAO) VALUES ('MH002','ĐỒ CHƠI','admin')
INSERT INTO MATHANG(MAMH,TENMATHANG,NGUOITAO) VALUES ('MH003','DỤNG CỤ','admin')
--
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH001',N'SÁCH TRONG NƯỚC','MH001','admin')
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH002',N'Foreign books','MH001','admin')
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH003',N'Đồ chơi','MH002','admin')
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH004',N'VPP-Dụng cụ học sinh','MH003','admin')

--
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH001',N'VĂN HỌC','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH002',N'KINH TẾ','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH003',N'TÂM LÝ - KỸ NĂNG SỐNG','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH004',N'NUÔI DẬY CON','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH005',N'SÁCH THIẾU NHI','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH006',N'TIỂU SỬ - HỒI KÝ','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH007',N'GIÁO KHOA - KHAM KHẢO','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH008',N'SÁCH HỌC NGOẠI NGỮ','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH009',N'BÚT - VIẾT','LMH004','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH010',N'DỤNG CỤ HỌC SINH','LMH004','admin')
--
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH001',N'Tiểu Thuyết','CDH001','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH002',N'Truyên ngắn -  Tàn Văn','CDH001','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH003',N'Ngôn tình','CDH001','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH004',N'Sách giáo khoa','CDH007','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH005',N'Sách tham khảo','CDH007','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH006',N'Bút Bi - Ruột Bút Bi','CDH009','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH007',N'Gôm - Tẩy','CDH010','admin')
--
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('d-day2_840x320_edit_moi.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('HoiSachOnline_T322_mainbanner__840x320_moi.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_-_DISNEY-100.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_-_Alphabooks_.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_Dong_A_edit_moi.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_-_Shopeepay_T3-100.jpg','admin')
--
INSERT INTO NHACC(MANCC,TENCC) VALUES ('NC001','Cty Phương Nam')
--
INSERT INTO NHAXB(MANXB,TENNXB) VALUES ('NXB01','NXB Giáo Dục Việt Nam')
--
insert into TACGIA (MATG,TENTG,NGUOITAO) values ('TG001',N'Bộ Giáo Dục Và Đào Tạo','admin')
insert into TACGIA (MATG,TENTG,NGUOITAO) values ('TG002',N'Nam Cao','admin')
insert into TACGIA (MATG,TENTG,NGUOITAO) values ('TG003',N'Tô Hoài','admin')
--
INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP001',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP001','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP001','image_241202.jpg')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP001','2021_06_03_14_12_35_2-390x510.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP001','LCDH004')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP001','LCDH005')

--
INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP002',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP002','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP002','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP002','LCDH004')

INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP003',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP003','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP003','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP003','LCDH004')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP003','LCDH005')

INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP004',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP004','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP004','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP004','LCDH004')

INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP005',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP005','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP005','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP005','LCDH004')


INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP006',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP006','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP006','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP006','LCDH004')
select * from CHUDE where disabled=0 and MALOAI='LMH001'

select * from LOAICHUDE where disabled=0 and macd='CDH001'

select * from QUANGCAO where disabled=0

select * from KHACHHANG

select * from NHACC

select * from SANPHAMHINHANH select Top 4 SANPHAM.MASP,TenSp,GIABAN  from SanPham,DONHANGCT where SANPHAM.MASP=DONHANGCT.MASP and disabled=0  
group by SANPHAM.MASP,TenSp,GIABAN 
having SUM(DONHANGCT.SL)>=10
order by SANPHAM.MASP,TenSp,GIABAN


select DISTINCT  SANPHAM.MASP,SANPHAM.TENSP,GIABAN from SANPHAM Inner join SACHTG on (SACHTG.MASP=SANPHAM.MASP)  Inner join TACGIA on (SACHTG.MATG=SACHTG.MATG)  where (TENSP like N'%%' or SANPHAM.MASP like N'%%' or TENTG like N'%%')  and SANPHAM.disabled=0 union  ALL  select DISTINCT  SANPHAM.MASP,SANPHAM.TENSP,GIABAN from SANPHAM LEFT join SACHTG on (SACHTG.MASP=SANPHAM.MASP) where (TENSP like N'%%' or SANPHAM.MASP like N'%%') and SANPHAM.disabled=0

update DONHANG set tongtien+=(select THANHTIEN from DONHANGCT where masp='SP002' and MADH=1003) where MADH=1003

insert into Sanpham(MASP,TENSP,MOTA,GIABAN,GIANHAP,KICHTHUOC,SOTRANG,DOTUOI,TRONGLUONG,MANCC,MANXB,NGONNGU,XUATXU) values(N'123',N'321','123','321',N'312','321','321',N'321','312','NC001   ','NXB01     ',N'Anh',N'Anh')

select LOAICHUDE.* from LOAICHUDE Inner join CHUDE on (LOAICHUDE.MACD=CHUDE.MACD) Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI)  Inner join MATHANG on (LOAIMATHANG.MAMH=MATHANG.MAMH) where LOAICHUDE.disabled=0 and MATHANG.MAMH= 'MH001'
select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,CHUDE.MACD from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) 
Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) 
Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD)
Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI) where LOAIMATHANG.MAMH = "MH001"


select * from SANPHAMHINHANH where disabled=0  and masp='3  '
update PHIEUNHAP set trangthai = 0
select * from SANPHAMHINHANH where masp='SP005'

select * from MATHANG where disabled=0

select Count(*) from LOAIMATHANG where LOAIMATHANG.MALOAI='LMH004'

select * from LOAICHUDE wher MACD='CDH001'

select * from SANPHAMCN
select * from LOAIQUYEN
insert into SANPHAMCN(macn,masp,NGAYTAO) values(N'MACN01','SP001',N'admin')

update PHIEUNHAP set TRANGTHAI= 0 where MAPHIEU=1

update QUYEN set MAQUYEN= 'AdminiStrator',TenQuyen =N'Admin' where IDQUYEN=1

update SANPHAMCN set SLTON= SLTON + 3 where masp='SP003     ' and macn= '1'

update LOAIQUYENOFNHANVIEN
set LOAIQUYENOFNHANVIEN.disabled = 1
from NHANVIEN where IDQUYEN='1' and LOAIQUYENOFNHANVIEN.IDLOAIQUYEN ='4'

select LOAIQUYEN.IDLOAIQUYEN,MALOAIQUYEN,TenLoaiQuyen from LOAIQUYENOFNHANVIEN,NHANVIEN,LOAIQUYEN where LOAIQUYENOFNHANVIEN.MANV =  NHANVIEN.MANV and LOAIQUYEN.IDLOAIQUYEN = LOAIQUYENOFNHANVIEN.IDLOAIQUYEN and NHANVIEN.IDQUYEN = '1' and LOAIQUYEN.IDLOAIQUYEN IN (select IDLOAIQUYEN from LOAIQUYENOFQUYEN where IDQUYEN='1' and disabled = 0)