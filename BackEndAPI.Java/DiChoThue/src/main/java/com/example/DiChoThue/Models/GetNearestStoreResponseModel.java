package com.example.DiChoThue.Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetNearestStoreResponseModel {
    int ma_cua_hang;
    String ten_cua_hang;
    double distance;
}
