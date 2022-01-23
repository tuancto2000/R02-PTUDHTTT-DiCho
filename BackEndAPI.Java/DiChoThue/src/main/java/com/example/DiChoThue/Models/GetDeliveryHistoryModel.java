package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetDeliveryHistoryModel {
    private int ma_don_hang;
    private int ma_cua_hang;
    private String ten_cua_hang;
    private int tongtien;
    private int trang_thai;
    private String ten_nguoi_nhan;
    private String sdt;
    private String dia_chi;
}
