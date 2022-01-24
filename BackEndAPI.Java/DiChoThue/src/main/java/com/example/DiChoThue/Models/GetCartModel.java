package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetCartModel {
    private int id;
    private int ma_gio_hang;
    private int ma_sp;
    private int so_luong;
    private String ten_sp;
    private int gia_sp;
    private int so_luong_con_lai;
    private String mo_ta;
    private int soluotdanhgia;
    private float trungbinhsao;
    private boolean trang_thai;
    private String nguon_hinh_anh;
}
