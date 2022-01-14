package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class CuaHangModel {
    private int MA_CUA_HANG;
    private int MA_NGUOI_DUNG;
    private String SDT;
    private String EMAIL;
    private String TEN_CUA_HANG;
    private String MA_DIA_CHI;
}
