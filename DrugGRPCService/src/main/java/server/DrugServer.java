package server;

import impl.DrugServiceImpl;
import io.grpc.Server;
import io.grpc.ServerBuilder;
import service.drug.GrpcDrugService;

import java.io.IOException;

public class DrugServer {
    public static void main(String[] args) throws IOException, InterruptedException {

        Server server = ServerBuilder
                .forPort(8005)
                .addService(new DrugServiceImpl()).build();

        server.start();
        server.awaitTermination();
    }
}
