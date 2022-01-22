package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.CuaHang;
import com.example.DiChoThue.Entities.DonHang;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.GetCommissionModel;
import com.example.DiChoThue.Models.GetNearestStoreRequestModel;
import com.example.DiChoThue.Models.GetNearestStoreResponseModel;
import com.example.DiChoThue.Repository.DiaChiRepository;
import com.example.DiChoThue.Repository.DonHangRepository;
import com.example.DiChoThue.Repository.NguoiDungRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import javax.validation.Valid;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("/api/stores")
public class StoresController {
    @Autowired
    DonHangRepository donHangRepository;

    @Autowired
    private EntityManager entityManager;

    @Autowired
    private NguoiDungRepository nguoiDungRepository;

    @Autowired
    private DiaChiRepository diaChiRepository;

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
        List<GetNearestStoreResponseModel> nearestStoreResponseModels = new ArrayList<>();

        int a = diaChiRepository.getNearestAddress(getNearestStoreRequestModel.getMa_nguoi_dung());

        System.out.println(a);
//        try {
//            nearestStoreResponseModels = diaChiRepository.getNearestAddress(getNearestStoreRequestModel.getMa_nguoi_dung());
//        }
//        catch (Exception e) {
//            System.out.println("lỗi");
//        }
        return ResponseEntity.ok().body(nearestStoreResponseModels);
    }
}
