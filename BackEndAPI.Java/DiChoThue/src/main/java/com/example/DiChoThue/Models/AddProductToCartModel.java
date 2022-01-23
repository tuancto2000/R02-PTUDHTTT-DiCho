package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class AddProductToCartModel {
    private int ma_nguoi_dung;
    private int ma_sp;
    private int so_luong;
}
