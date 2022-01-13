package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "CHI_TIET_DON_HANG")
public class ChiTietDonHang {
    @Id
    private int Id;
    private int MA_DON_HANG;
    private int MA_SP;
    private int SO_LUONG;
    private int DON_GIA;
}
