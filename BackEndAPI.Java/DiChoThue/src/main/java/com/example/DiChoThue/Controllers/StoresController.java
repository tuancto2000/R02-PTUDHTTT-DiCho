package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.CuaHang;
import com.example.DiChoThue.Entities.DiaChi;
import com.example.DiChoThue.Entities.DonHang;
import com.example.DiChoThue.Entities.NguoiDung;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.CoordinateModel;
import com.example.DiChoThue.Models.GetCommissionModel;
import com.example.DiChoThue.Models.GetNearestStoreRequestModel;
import com.example.DiChoThue.Models.GetNearestStoreResponseModel;
import com.example.DiChoThue.Repository.DonHangRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import javax.validation.Valid;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("/api/stores")
public class StoresController {
    @Autowired
    DonHangRepository donHangRepository;

    @Autowired
    private EntityManager entityManager;

    @GetMapping("/{storeId}/commission")
    public ResponseEntity<GetCommissionModel> getCommission(@PathVariable(value = "storeId") Integer storeId,
                                                            @RequestParam(value = "date_start", required = false) String date_start,
                                                            @RequestParam(value = "date_end", required = false) String date_end)
            throws ResourceNotFoundException {
        final double commission = 0.1;

        SimpleDateFormat formatter = new SimpleDateFormat("yyyy-M-dd hh:mm:ss");
        String sql = "";

        if (date_start == null && date_end == null) {
            sql = "Select new " + GetCommissionModel.class.getName()
                    + "(dh.ma_cua_hang, ch.ten_cua_hang, sum(dh.tongtien) as doanh_thu, (sum(dh.tongtien) * " + commission + ") as hoa_hong) "
                    + "from " + DonHang.class.getName() + " dh join " + CuaHang.class.getName() + " ch on dh.ma_cua_hang = ch.ma_cua_hang "
                    + "where dh.trang_thai = 5 and dh.ma_cua_hang = " + storeId + " group by dh.ma_cua_hang, ch.ten_cua_hang";
        } else {
            if (date_start == null) {
                date_start = formatter.format(donHangRepository.getOldestSellDate(storeId));
            } else if (date_end == null) {
                date_end = formatter.format(new Date());
            }
            sql = "Select new " + GetCommissionModel.class.getName()
                    + "(dh.ma_cua_hang, ch.ten_cua_hang, sum(dh.tongtien) as doanh_thu, (sum(dh.tongtien) * " + commission + ") as hoa_hong) "
                    + "from " + DonHang.class.getName() + " dh join " + CuaHang.class.getName() + " ch on dh.ma_cua_hang = ch.ma_cua_hang "
                    + "where dh.trang_thai = 5 and dh.ma_cua_hang = " + storeId + " and '"
                    + date_start + "' <= dh.ngay_mua and dh.ngay_mua <= '" + date_end + "' group by dh.ma_cua_hang, ch.ten_cua_hang";
        }

        Query query = entityManager.createQuery(sql, GetCommissionModel.class);
        return ResponseEntity.ok().body((GetCommissionModel) query.getSingleResult());
    }

    @Transactional
    @PostMapping("/nearest-stores")
    public ResponseEntity<List<GetNearestStoreResponseModel>> getNearestStore(@Valid @RequestBody GetNearestStoreRequestModel getNearestStoreRequestModel)
            throws ResourceNotFoundException {
        final int distance = 100000;

        String sql = "Select new " + CoordinateModel.class.getName()
                + "(dc.toa_do_dong, dc.toa_do_bac) from " + NguoiDung.class.getName() + " nd join " + DiaChi.class.getName() + " dc"
                + " on nd.ma_dia_chi = dc.ma_dia_chi where nd.ma_nguoi_dung = " + getNearestStoreRequestModel.getMa_nguoi_dung();

        Query query = entityManager.createQuery(sql, CoordinateModel.class);
        CoordinateModel coordinate = (CoordinateModel) query.getSingleResult();

        sql = "Select new " + GetNearestStoreResponseModel.class.getName()
                + "(ch.ma_cua_hang, ch.ten_cua_hang, SQRT(" +
                "POWER(CONVERT(bigint,(dc.toa_do_dong - " + coordinate.getToa_do_dong() + ")), 2) + " +
                "POWER(CONVERT(bigint,(dc.toa_do_bac - " + coordinate.getToa_do_bac() + ")), 2)) AS khoang_cach) "
                + " from " + DiaChi.class.getName() + " dc join " + CuaHang.class.getName() + " ch on dc.ma_dia_chi = ch.ma_dia_chi"
                + " where SQRT(" +
                "POWER(CONVERT(bigint,(dc.toa_do_dong - " + coordinate.getToa_do_dong() + ")), 2) + " +
                "POWER(CONVERT(bigint,(dc.toa_do_bac - " + coordinate.getToa_do_bac() + ")), 2)) < " + distance + " order by khoang_cach";
        query = entityManager.createQuery(sql, GetNearestStoreResponseModel.class);

        return ResponseEntity.ok().body(query.getResultList());
    }
}
