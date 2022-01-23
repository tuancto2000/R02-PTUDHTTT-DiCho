package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class NguoiDungModel {
    private int MA_NGUOI_DUNG;
    private String TEN_NGUOI_DUNG;
    private Date NGAY_SINH;
    private String DIA_CHI;
    private String SDT;
    private String EMAIL;
}
