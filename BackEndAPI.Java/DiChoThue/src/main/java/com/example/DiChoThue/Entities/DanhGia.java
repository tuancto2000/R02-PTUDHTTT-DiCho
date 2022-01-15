package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "DANH_GIA")
public class DanhGia {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_danh_gia;
    private int ma_nguoi_dung;
    private int ma_chi_tiet_don_hang;
    private int ma_san_pham;
    private int sao;
    private String binh_luan;
}
