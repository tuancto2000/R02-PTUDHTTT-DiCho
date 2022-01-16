package com.example.DiChoThue.Models;

import com.example.DiChoThue.Entities.HinhAnh;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UpdateProductModel {
    private int ma_cua_hang;
    private int ma_dm;
    private String ten_sp;
    private int gia_sp;
    private int so_luong_con_lai;
    private String mo_ta;
    private List<HinhAnh> hinh_anh;
}
