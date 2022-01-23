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
@Table(name = "HOP_DONG")
public class HopDong {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_hop_dong;
    private int ma_nguoi_dung;
    private Date ngay_ky_hop_dong;
    private Date ngay_hieu_luc;
    private Date ngay_ket_thuc;
    private String chungNhanAnToanImg;
    private String giayPhepKinhDoanhImg;
    private String hopDongImg;
    private Date ngayDangKy;
}
