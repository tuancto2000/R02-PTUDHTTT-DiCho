package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class SanPhamModel {
    private int ma_sp;
    private String ten_sp;
    private int ma_dm;
    private String ten_dm;
    private int ma_cua_hang;
    private String ten_cua_hang;
    private int gia_sp;
    private int so_luong_con_lai;
    private String mo_ta;
    private int soluotdanhgia;
    private float trungbinhsao;
}
