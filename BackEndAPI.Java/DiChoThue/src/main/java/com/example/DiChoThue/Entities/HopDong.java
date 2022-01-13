package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "HOP_DONG")
public class HopDong {
    @Id
    private int MA_HOP_DONG;
    private int MA_NGUOI_DUNG;
    private Date NGAY_KY_HOP_DONG;
    private Date NGAY_HIEU_LUC;
    private Date NGAY_KET_THUC;
}
