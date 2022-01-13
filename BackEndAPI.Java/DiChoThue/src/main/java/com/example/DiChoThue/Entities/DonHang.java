package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "DON_HANG")
public class DonHang {
    @Id
    private int MA_DON_HANG;
    private int MA_NGUOI_DUNG;
    private int MA_CUA_HANG;
    private int MA_SHIPPER;
    private String DIA_CHI;
    private Date NGAY_MUA;
    private int TRANG_THAI;
    private Date NGAY_CAP_NHAT;
    private String TEN_NGUOI_NHAN;
    private String SDT;
    private String PHAN_HOI;
}
