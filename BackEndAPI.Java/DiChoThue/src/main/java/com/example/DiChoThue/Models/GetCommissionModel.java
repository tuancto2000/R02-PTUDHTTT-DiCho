package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetCommissionModel {
    private int ma_cua_hang;
    private String ten_cua_hang;
    private long doanh_thu;
    private double hoa_hong;
}
