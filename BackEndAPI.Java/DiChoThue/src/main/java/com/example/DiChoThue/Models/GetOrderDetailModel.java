package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetOrderDetailModel {
    private int id;
    private int ma_sp;
    private String ten_sp;
    private String nguon_hinh_anh;
    private int so_luong;
    private int don_gia;
    private int thanh_tien;
}
