pipeline {
  agent {
    node {
      label 'ubuntu_agent_netcore3'
    }

  }
  stages {
    stage('test') {
      steps {
        sh 'dotnet test addressbook-web-test/addressbook-web-test.sln --logger "trx;LogFileName=resultfile.trx"'
      }
    }

    stage('CleanUp') {
      steps {
        cleanWs(cleanWhenAborted: true, cleanWhenFailure: true, cleanWhenNotBuilt: true, cleanWhenSuccess: true, deleteDirs: true, cleanWhenUnstable: true, cleanupMatrixParent: true, disableDeferredWipeout: true)
      }
    }

  }
  post {
    always {
      emailext(attachLog: true, to: 'a.vergel@radico.ru', from: 'autotoster@radico.ru', subject: "${currentBuild.result} test ${currentBuild.fullDisplayName}", body: "Tests Report: ${env.RUN_DISPLAY_URL}")
      archiveArtifacts(artifacts: 'NUnitTestProject/TestResults/*.trx', fingerprint: true)
      nunit(testResultsPattern: 'NUnitTestProject/TestResults/*.xml')
      mstest(testResultsFile: 'NUnitTestProject/TestResults/*.trx, keepLongStdio: true')
    }

  }
  triggers {
    upstream(upstreamProjects: 'IDKAPIServer/master', threshold: hudson.model.Result.SUCCESS)
  }
}