package com.example.DiChoThue.Models;

import com.example.DiChoThue.Entities.ChiTietGioHang;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UpdateCartModel {
    private int ma_nguoi_dung;
    List<ChiTietGioHang> chitietgiohang_list;
}
