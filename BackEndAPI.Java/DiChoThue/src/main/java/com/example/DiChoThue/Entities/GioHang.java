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
@Table(name = "GIO_HANG")
public class GioHang {
    @Id
    private int MA_GIO_HANG;
    private int MA_NGUOI_DUNG;
    private int TONG_TIEN;
}
