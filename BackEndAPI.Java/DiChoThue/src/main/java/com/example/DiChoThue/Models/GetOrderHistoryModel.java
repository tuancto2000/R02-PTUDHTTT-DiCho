package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetOrderHistoryModel {
    private int ma_don_hang;
    private int ma_cua_hang;
    private String ten_cua_hang;
    private int tongtien;
    private int trang_thai;
    private Date ngay_mua;
}
