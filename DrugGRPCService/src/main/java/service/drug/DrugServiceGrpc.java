package service.drug;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.35.0)",
    comments = "Source: GrpcDrugService.proto")
public final class DrugServiceGrpc {

  private DrugServiceGrpc() {}

  public static final String SERVICE_NAME = "service.drug.DrugService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<service.drug.DrugRequest,
      service.drug.DrugResponse> getOrderDrugMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "orderDrug",
      requestType = service.drug.DrugRequest.class,
      responseType = service.drug.DrugResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<service.drug.DrugRequest,
      service.drug.DrugResponse> getOrderDrugMethod() {
    io.grpc.MethodDescriptor<service.drug.DrugRequest, service.drug.DrugResponse> getOrderDrugMethod;
    if ((getOrderDrugMethod = DrugServiceGrpc.getOrderDrugMethod) == null) {
      synchronized (DrugServiceGrpc.class) {
        if ((getOrderDrugMethod = DrugServiceGrpc.getOrderDrugMethod) == null) {
          DrugServiceGrpc.getOrderDrugMethod = getOrderDrugMethod =
              io.grpc.MethodDescriptor.<service.drug.DrugRequest, service.drug.DrugResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "orderDrug"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  service.drug.DrugRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  service.drug.DrugResponse.getDefaultInstance()))
              .setSchemaDescriptor(new DrugServiceMethodDescriptorSupplier("orderDrug"))
              .build();
        }
      }
    }
    return getOrderDrugMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static DrugServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<DrugServiceStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<DrugServiceStub>() {
        @Override
        public DrugServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new DrugServiceStub(channel, callOptions);
        }
      };
    return DrugServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static DrugServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<DrugServiceBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<DrugServiceBlockingStub>() {
        @Override
        public DrugServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new DrugServiceBlockingStub(channel, callOptions);
        }
      };
    return DrugServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static DrugServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<DrugServiceFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<DrugServiceFutureStub>() {
        @Override
        public DrugServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new DrugServiceFutureStub(channel, callOptions);
        }
      };
    return DrugServiceFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class DrugServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void orderDrug(service.drug.DrugRequest request,
        io.grpc.stub.StreamObserver<service.drug.DrugResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getOrderDrugMethod(), responseObserver);
    }

    @Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getOrderDrugMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                service.drug.DrugRequest,
                service.drug.DrugResponse>(
                  this, METHODID_ORDER_DRUG)))
          .build();
    }
  }

  /**
   */
  public static final class DrugServiceStub extends io.grpc.stub.AbstractAsyncStub<DrugServiceStub> {
    private DrugServiceStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected DrugServiceStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new DrugServiceStub(channel, callOptions);
    }

    /**
     */
    public void orderDrug(service.drug.DrugRequest request,
        io.grpc.stub.StreamObserver<service.drug.DrugResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getOrderDrugMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class DrugServiceBlockingStub extends io.grpc.stub.AbstractBlockingStub<DrugServiceBlockingStub> {
    private DrugServiceBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected DrugServiceBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new DrugServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public service.drug.DrugResponse orderDrug(service.drug.DrugRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getOrderDrugMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class DrugServiceFutureStub extends io.grpc.stub.AbstractFutureStub<DrugServiceFutureStub> {
    private DrugServiceFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected DrugServiceFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new DrugServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<service.drug.DrugResponse> orderDrug(
        service.drug.DrugRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getOrderDrugMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_ORDER_DRUG = 0;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final DrugServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(DrugServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @Override
    @SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_ORDER_DRUG:
          serviceImpl.orderDrug((service.drug.DrugRequest) request,
              (io.grpc.stub.StreamObserver<service.drug.DrugResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @Override
    @SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class DrugServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    DrugServiceBaseDescriptorSupplier() {}

    @Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return service.drug.GrpcDrugService.getDescriptor();
    }

    @Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("DrugService");
    }
  }

  private static final class DrugServiceFileDescriptorSupplier
      extends DrugServiceBaseDescriptorSupplier {
    DrugServiceFileDescriptorSupplier() {}
  }

  private static final class DrugServiceMethodDescriptorSupplier
      extends DrugServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    DrugServiceMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (DrugServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new DrugServiceFileDescriptorSupplier())
              .addMethod(getOrderDrugMethod())
              .build();
        }
      }
    }
    return result;
  }
}
