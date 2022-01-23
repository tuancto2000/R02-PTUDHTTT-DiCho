package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "DON_HANG")
public class DonHang {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_don_hang;
    private int ma_nguoi_dung;
    private int ma_cua_hang;
    private int ma_shipper;
    private String dia_chi;
    private Date ngay_mua;
    private int trang_thai;
    private Date ngay_cap_nhat;
    private String ten_nguoi_nhan;
    private String sdt;
    private String phan_hoi;
    private int tongtien;
}
