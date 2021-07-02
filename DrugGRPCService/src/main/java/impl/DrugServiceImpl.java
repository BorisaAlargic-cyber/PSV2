package impl;

import service.drug.DrugResponse;
import service.drug.DrugServiceGrpc;

public class DrugServiceImpl extends DrugServiceGrpc.DrugServiceImplBase {

    public void orderDrug(service.drug.DrugRequest request,
                          io.grpc.stub.StreamObserver<service.drug.DrugResponse> responseObserver) {

        int id = Integer.parseInt(request.getDrugId());

        String response = "ACCEPT";

        if(id % 2 == 1) {
            response = "REJECT";
        }

        DrugResponse res = DrugResponse.newBuilder()
                .setStatus("OK")
                .build();

        responseObserver.onNext(res);
        responseObserver.onCompleted();
    }

}
