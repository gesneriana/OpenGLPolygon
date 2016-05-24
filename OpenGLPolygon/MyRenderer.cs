using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Javax.Microedition.Khronos.Egl;
using Javax.Microedition.Khronos.Opengles;
using static Android.Opengl.GLSurfaceView;
using Java.Nio;

namespace OpenGLPolygon
{
    /// <summary>
    /// ʵ���Զ������Ⱦ����
    /// �̳�Java.Lang.Object���Բ�������Dispose()������Handle����
    /// </summary>
    public class MyRenderer : Java.Lang.Object, IRenderer
    {
        float[] triangleData = new float[]
        {
            0.1f,0.6f,0.0f,     // �϶���
            -0.3f,0.0f,0.0f,    // �󶥵�
            0.3f,0.1f,0.0f      // �Ҷ���
        };

        int[] triangleColor = new int[]
        {
            65535,0,0,0,    // �϶����ɫ
            0,65535,0,0,    // �󶥵���ɫ
            0,0,65535,0     // �Ҷ�����ɫ
        };

        float[] rectData = new float[]
        {
            0.4f,0.4f,0.0f,     // ���϶���
            0.4f,-0.4f,0.0f,    // ���¶���
            -0.4f,0.4f,0.0f,    // ���϶���
            -0.4f,-0.4f,0.0f    // ���¶���
        };

        int[] rectColor = new int[]
        {
            0,65535,0,0,        // ���϶�����ɫ
            0,0,65535,0,        // ���¶�����ɫ
            65535,0,0,0,        // ���϶����ɫ
            65535,65535,0,0     // ���¶����ɫ
        };

        /// <summary>
        /// ��Ȼ�������ε��ĸ�����,ֻ��˳�򽻻���һ��
        /// </summary>
        float[] rectData2 = new float[]
        {
            -0.4f,0.4f,0.0f,    // ���϶���
            0.4f,0.4f,0.0f,     // ���϶���
            0.4f,-0.4f,0.0f,    // ���¶���
            -0.4f,-0.4f,0.0f    // ���¶���
        };

        /// <summary>
        /// �������
        /// </summary>
        float[] pentacle = new float[]
        {
            0.4f,0.4f,0.0f,
            -0.2f,0.3f,0.0f,
            0.5f,0.0f,0f,
            -0.4f,0.0f,0f,
            -0.1f,-0.3f,0f
        };

        FloatBuffer triangleDataBuffer;
        IntBuffer triangleColorBuffer;
        FloatBuffer rectDataBuffer;
        IntBuffer rectColorBuffer;
        FloatBuffer rectDataBuffer2;
        FloatBuffer pentacleBuffer;


        /// <summary>
        /// �ص�,ע�͵���Wrap()�����ᵼ�� called a GL11 Pointer method with an indirect Buffer ����
        /// ʹ��bufferUtil()���������޸��������
        /// </summary>
        public MyRenderer()
        {
            // ������λ�������װ��FloatBuffer;
            /*
            triangleDataBuffer = FloatBuffer.Wrap(triangleData);
            rectDataBuffer = FloatBuffer.Wrap(rectData);
            rectDataBuffer2 = FloatBuffer.Wrap(rectData2);
            pentacleBuffer = FloatBuffer.Wrap(pentacle);
            */
            triangleDataBuffer = bufferUtil(triangleData);
            rectDataBuffer = bufferUtil(rectData);
            rectDataBuffer2 = bufferUtil(rectData2);
            pentacleBuffer = bufferUtil(pentacle);
            // ��������ɫ���������װ��IntBuffer
            /*
            triangleColorBuffer = IntBuffer.Wrap(triangleColor);
            rectColorBuffer = IntBuffer.Wrap(rectColor);
            */
            triangleColorBuffer = bufferUtil(triangleColor);
            rectColorBuffer = bufferUtil(rectColor);
        }

        /// <summary>
        /// ����ͼ�εķ���
        /// </summary>
        /// <param name="gl"></param>
        public void OnDrawFrame(IGL10 gl)
        {
            // �����Ļ�������Ȼ���
            gl.GlClear(GL10.GlColorBufferBit | GL10.GlDepthBufferBit);
            // ���ö�����������
            gl.GlEnableClientState(GL10.GlVertexArray);
            // ���ö�����ɫ����
            gl.GlEnableClientState(GL10.GlColorArray);
            // ���õ�ǰ�����ջΪģ�Ͷ�ջ
            gl.GlMatrixMode(GL10.GlModelview);

            // ------���Ƶ�һ��ͼ��--------
            // ���õ�ǰ��ģ����ͼ����
            gl.GlLoadIdentity();
            gl.GlTranslatef(-0.32f, 0.35f, -1f);
            // ���ö����λ������
            gl.GlVertexPointer(3, GL10.GlFloat, 0, triangleDataBuffer);
            // ���ö������ɫ����
            gl.GlColorPointer(4, GL10.GlFloat, 0, triangleColorBuffer);
            // ���ݶ������ݻ���ƽ��ͼ��
            gl.GlDrawArrays(GL10.GlTriangles, 0, 3);

            // ---------���Ƶڶ���ͼ��------------
            // ���õ�ǰ��ģ����ͼ����
            gl.GlLoadIdentity();
            gl.GlTranslatef(0.6f, 0.8f, -1.5f);
            // ���ö����λ������
            gl.GlVertexPointer(3, GL10.GlFloat, 0, rectDataBuffer);
            // ���ö������ɫ����
            gl.GlColorPointer(4, GL10.GlFixed, 0, rectColorBuffer);
            // ���ݶ������ݻ���ƽ��ͼ��
            gl.GlDrawArrays(GL10.GlTriangleStrip, 0, 4);

            // --------���Ƶ�����ͼ��------------
            // ���õ�ǰ��ģ����ͼ����
            gl.GlLoadIdentity();
            gl.GlTranslatef(-0.4f, -0.5f, -1.5f);
            // ���ö����λ������(ʹ��֮ǰ�Ķ�����ɫ)
            gl.GlVertexPointer(3, GL10.GlFloat, 0, rectDataBuffer2);
            // ���ݶ������ݻ���ƽ��ͼ��
            gl.GlDrawArrays(GL10.GlTriangleStrip, 0, 4);

            // --------���Ƶ�4��ͼ��--------------
            // ���õ�ǰ��ģ����ͼ����
            gl.GlLoadIdentity();
            gl.GlTranslatef(0.4f, -0.5f, -1.5f);
            // ����ʹ�ô�ɫ���
            gl.GlColor4f(1.0f, 0.2f, 0.2f, 0.0f);
            gl.GlDisableClientState(GL10.GlColorArray);
            // ���ö����λ������
            gl.GlVertexPointer(3, GL10.GlFloat, 0, pentacleBuffer);
            // ���ݶ������ݻ���ƽ��ͼ��
            gl.GlDrawArrays(GL10.GlTriangleStrip, 0, 5);
            // ���ƽ���
            gl.GlFinish();
            gl.GlDisableClientState(GL10.GlVertexArray);
        }


        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            // ����3D�Ӵ��Ĵ�С��λ��
            gl.GlViewport(0, 0, width, height);
            // ����ǰ����ģʽ��ΪͶӰ����
            gl.GlMatrixMode(GL10.GlProjection);
            // ��ʼ����λ����
            gl.GlLoadIdentity();
            // ����͸���Ӵ��Ŀ��,�߶ȱ�
            float ratio = (float)width / height;
            // ���ô˷�������͸���Ӵ��Ŀռ��С
            gl.GlFrustumf(-ratio, ratio, -1, 1, 1, 10);
        }

        public void OnSurfaceCreated(IGL10 gl, EGLConfig config)
        {
            // �رտ�����
            gl.GlDisable(GL10.GlDither);
            // ����ϵͳ��͸�ӽ�������
            gl.GlHint(GL10.GlPerspectiveCorrectionHint, GL10.GlFastest);
            gl.GlClearColor(0, 0, 0, 0);
            // ������Ӱƽ��ģʽ
            gl.GlShadeModel(GL10.GlSmooth);
            // ������Ȳ���
            gl.GlEnable(GL10.GlDepthTest);
            // ������Ȳ��Ե�����
            gl.GlDepthFunc(GL10.GlLequal);
        }

        public IntBuffer bufferUtil(int[] arr)
        {
            IntBuffer buffer;

            ByteBuffer qbb = ByteBuffer.AllocateDirect(arr.Length * 4);
            qbb.Order(ByteOrder.NativeOrder());

            buffer = qbb.AsIntBuffer();
            buffer.Put(arr);
            buffer.Position(0);

            return buffer;
        }

        public FloatBuffer bufferUtil(float[] arr)
        {
            FloatBuffer buffer;

            ByteBuffer qbb = ByteBuffer.AllocateDirect(arr.Length * 4);
            qbb.Order(ByteOrder.NativeOrder());

            buffer = qbb.AsFloatBuffer();
            buffer.Put(arr);
            buffer.Position(0);

            return buffer;
        }

    }
}